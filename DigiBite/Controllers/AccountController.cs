using DigiBite_Core.Constant;
using DigiBite_Core.Context;
using DigiBite_Core.DTOs.Account;
using DigiBite_Core.DTOs.Email;
using DigiBite_Core.IServices;
using DigiBite_Core.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DigiBite_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        RoleManager<IdentityRole> roleManager,
        DigiBiteContext context,
        IConfiguration config,
        IEmailService emailSender,
        IMediaService mediaService
        ) : ControllerBase
    {

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="input">The user details.</param>
        /// <response code="201">Registration successful.</response>
        /// <response code="400">Bad request, e.g., phone number already taken.</response>
        /// <response code="500">Internal server error.</response>
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> Signup(SignupDTO input)
        {
            using var transaction = await context.Database.BeginTransactionAsync();

            try
            {

                var user = new AppUser
                {
                    Email = input.Email,
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    PhoneNumber = input.PhoneNumber,
                    UserName = input.Email,
                };


                var createResult = await userManager.CreateAsync(user, input.Password);
                if (!createResult.Succeeded)
                    throw new Exception(createResult.Errors.First().Description);


                var addRoleResult = await userManager.AddToRoleAsync(user, Role.Customer.ToString());
                if (!addRoleResult.Succeeded)
                    throw new Exception(addRoleResult.Errors.First().Description);


                await transaction.CommitAsync();

                return StatusCode(201, "Registration successfully completed.");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                if (ex.InnerException?.Message.Contains("IX_AspNetUsers_PhoneNumber") == true)
                {
                    return StatusCode(400, $"Phone '{input.PhoneNumber}' is already taken.");
                }

                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Authenticates a user and generates a JWT token.
        /// </summary>
        /// <param name="input">The login credentials including username and password.</param>
        /// <response code="200">Login successful and JWT token is returned.</response>
        /// <response code="400">Invalid username or password.</response>
        /// <response code="403">Login not allowed, e.g., email not confirmed.</response>
        /// <response code="423">User account is locked.</response>
        /// <response code="500">Internal server error occurred during login.</response>
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(string), StatusCodes.Status423Locked)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> Login(LoginDTO input)
        {
            try
            {

                var result = await signInManager.PasswordSignInAsync(input.UserName, input.Password, false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    var user = await userManager.FindByNameAsync(input.UserName);

                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                    claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                    var roles = await userManager.GetRolesAsync(user);
                    foreach (var role in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
                        // Retrieve role claims
                        var rolesByName = await roleManager.FindByNameAsync(role);
                        if (rolesByName != null)
                        {
                            var roleClaims = await roleManager.GetClaimsAsync(rolesByName);
                            claims.AddRange(roleClaims);
                        }
                    }
                    //signingCredentials
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:SecretKey"]));
                    var sc = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        claims: claims,
                        issuer: config["JWT:Issuer"],
                        audience: config["JWT:Audience"],
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: sc
                        );

                    string _token = new JwtSecurityTokenHandler().WriteToken(token);
                   
                    return Ok(_token);
                }
                else if (result.IsLockedOut)
                {
                    return StatusCode(423, "User account is locked.");
                }
                else if (result.IsNotAllowed)
                {
                    return StatusCode(403, "Login is not allowed. Please confirm your email");
                }
                else
                {
                    return StatusCode(400, "Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to login: {ex.Message}");
            }
        }



        /// <summary>
        /// Sends a password reset link to the user's email.
        /// </summary>
        /// <param name="input">The email address of the user requesting a password reset.</param>
        /// <response code="200">Password reset link successfully sent.</response>
        /// <response code="400">Bad request, e.g., user not found or invalid email.</response>
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> ForgotPassword(InputEmailDTO input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await userManager.FindByEmailAsync(input.Email);
            if (user == null)
                return BadRequest("User not found");

            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            //var callbackUrl = Url.Action("ResetPassword", "Account", new { token, email = user.Email }, Request.Scheme);
            var callbackUrl = $"{config["AngularURL"]}/auth/restPass?token={Uri.EscapeDataString(token)}&email={Uri.EscapeDataString(user.Email)}";

            var emailData = new EmailDTO
            {
                EmailToId = user.Email,
                EmailToName = user.FirstName,
                EmailSubject = "Reset Your Password",
                EmailBody = $"Hello {user.FirstName}, \n\nIt looks like you requested a password reset." +
                " To reset your password," +
                $" please click the link below:\n\n{callbackUrl}\n\n" +
                "If you didn't request a password reset, please ignore this email." +
                "\n\nBest regards,\nDigiBite"

            };

            emailSender.SendMail(emailData);

            //return Ok(token);
            return Ok("reset link has been sent to your email.");
        }


        /// <summary>
        /// Resets the user's password.
        /// </summary>
        /// <param name="model">The password reset details including email, token, and new password.</param>
        /// <response code="200">Password reset successful.</response>
        /// <response code="400">Bad request, e.g., invalid or expired token.</response>
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return BadRequest("Invalid request.");

            var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (!result.Succeeded)
            {
                if (result.Errors.Any(e => e.Code == "InvalidToken"))
                {
                    return BadRequest("Invalid or expired token.");
                }
                return BadRequest(result.Errors);
            }

            return Ok("Password has been reset successfully.");
        }


        /// <summary>
        /// Sends a confirmation email to the user's email address.
        /// </summary>
        /// <param name="input">The email address of the user requesting email confirmation.</param>
        /// <response code="200">Confirmation email sent successfully.</response>
        /// <response code="400">Bad request, e.g., email is already confirmed.</response>
        /// <response code="404">User not found.</response>
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> SendConfirmationEmail([FromBody] InputEmailDTO input)
        {
            if (string.IsNullOrEmpty(input.Email))
                return BadRequest("Email is required");

            var user = await userManager.FindByEmailAsync(input.Email);
            if (user == null)
                return NotFound($"User with email '{input.Email}' not found");

            if (user.EmailConfirmed)
                return BadRequest("Email is already confirmed");

            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

            var callbackUrl = $"{config["AngularURL"]}/auth/ConfirmEmail?userId={Uri.EscapeDataString(user.Id)}&token={Uri.EscapeDataString(token)}";


            var emailData = new EmailDTO
            {
                EmailToId = user.Email,
                EmailToName = user.FirstName,
                EmailSubject = "Confirm your email",
                EmailBody = $"Hello {user.FirstName}, \n\n" +
                   " Please confirm your account by clicking below link:" +
                   $"\n\n{callbackUrl}\n\n" +
                   "If you didn't receive a link, please ignore this email." +
                   "\n\nBest regards,\nDigiBite"

            };
            emailSender.SendMail(emailData);

            var result = new { token, userId = user.Id };
            return Ok(result);
            //return Ok("Confirmation email has been sent.");
        }


        /// <summary>
        /// Confirms the user's email address.
        /// </summary>
        /// <param name="input">The user ID and email confirmation token.</param>
        /// <response code="200">Email confirmed successfully.</response>
        /// <response code="400">Bad request, e.g., invalid token or user ID.</response>
        /// <response code="404">User not found.</response>
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailDTO input)
        {
            if (string.IsNullOrEmpty(input.userId) || string.IsNullOrEmpty(input.token))
                return BadRequest("UserId and Token are required");

            var user = await userManager.FindByIdAsync(input.userId);

            if (user == null)
                return NotFound($"User with ID '{input.userId}' not found");

            var result = await userManager.ConfirmEmailAsync(user, input.token);

            if (result.Succeeded)
                return Ok("Email confirmed successfully!");

            return BadRequest("Error confirming email");
        }



        /// <summary>
        /// Updates the user's profile information.
        /// </summary>
        /// <param name="input">The updated profile details.</param>
        /// <response code="200">Profile updated successfully.</response>
        /// <response code="400">Bad request, e.g., invalid data or user not found.</response>
        /// <response code="500">Internal server error.</response>
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPatch]
        [Route("[Action]")]
        [Authorize]
        public async Task<IActionResult> UpdateProfile(UpdateProfileDTO input)
        {
            try
            {

                if (input.Gender != null && !Enum.IsDefined(typeof(Gender), input.Gender))
                {
                    return NotFound(string.Join(", ", Enum.GetValues<Gender>()
                        .Select(gender => $"Enter: '{(int)gender}' for {gender}")));
                }

                var user = await userManager.GetUserAsync(User);
                if (user == null)
                    return BadRequest("User not found.");

                user.Gender = input.Gender ?? user.Gender;
                user.FirstName = input.FirstName ?? user.FirstName;
                user.LastName = input.LastName ?? user.LastName;
                user.PhoneNumber = input.PhoneNumber ?? user.PhoneNumber;
                user.DateOfBirth = input.DateOfBirth ?? user.DateOfBirth;
                user.LastModifiedDateTime = DateTime.Now;

                var result = await userManager.UpdateAsync(user);

                if (!result.Succeeded)
                    return BadRequest(result.Errors);

                return Ok("Profile updated successfully.");
            }
            catch (Exception ex)
            {
                if (ex.InnerException?.Message.Contains("IX_AspNetUsers_PhoneNumber") == true)
                {
                    return StatusCode(400, $"Phone '{input.PhoneNumber}' is already taken.");
                }

                return StatusCode(500, $"Failed to update profile: {ex.Message}");
            }
        }


        /// <summary>
        /// Updates the user's profile Image.
        /// </summary>
        /// <param name="file">The image file</param>
        /// <response code="200">Profile Image updated successfully.</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal server error.</response>
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPatch]
        [Route("[Action]")]
        [Authorize]
        public async Task<IActionResult> UpdateProfileImage(IFormFile file)
        {
            try
            {
                var user = await userManager.GetUserAsync(User);
                if (user == null)
                    return BadRequest("User not found.");
                var temp = user.ProfileImgId ?? 0;

                var image = await mediaService.UploadProfileImage(file, user.Id);
                user.ProfileImgId = image.Id;
                user.LastModifiedDateTime = DateTime.Now;

                if (temp != 0)
                    await mediaService.RemoveFile(temp);

                var result = await userManager.UpdateAsync(user);

                if (!result.Succeeded)
                    return BadRequest(result.Errors.First().Description);

                return Ok(image.ImageUrl);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to update profile: {ex.Message}");
            }
        }


        /// <summary>
        /// Retrieves the user profile information.
        /// </summary>
        /// <response code="200">Profile retrieved successfully.</response>
        /// <response code="400">Bad request, e.g., user not found.</response>
        /// <response code="500">Internal server error.</response>
        [ProducesResponseType(typeof(UserProfileDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        [Route("[Action]")]
        //[Authorize]
        public async Task<IActionResult> GetProfile()
        {
            try
            {

                var user = await userManager.GetUserAsync(User);
                if (user == null)
                    return BadRequest("User not found.");

                var userProfile = new UserProfileDTO
                {
                    Gender = user.Gender,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    DateOfBirth = user.DateOfBirth,
                    Email = user.Email,
                    ProfileImgUrl = user.ProfileImgId == null 
                            ? null : await mediaService.GetFileUrlById(user.ProfileImgId??0)
                };

                return Ok(userProfile);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to retrieve profile: {ex.Message}");
            }
        }


    }
}
