using DigiBite_Core.Constant;
using DigiBite_Core.Context;
using DigiBite_Core.DTOs.Account;
using DigiBite_Core.Models.Entities;
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
        IConfiguration config) : ControllerBase
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
        /// Authenticates a user.
        /// </summary>
        /// <param name="input">The login credentials.</param>
        /// <response code="200">Login successful.</response>
        /// <response code="400">Invalid username or password.</response>
        /// <response code="403">Login not allowed.</response>
        /// <response code="423">User account is locked.</response>
        /// <response code="500">Internal server error.</response>
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
                    var _token = new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo,
                    };
                    return Ok(_token);
                }
                else if (result.IsLockedOut)
                {
                    return StatusCode(423, "User account is locked.");
                }
                else if (result.IsNotAllowed)
                {
                    return StatusCode(403, "Login is not allowed.");
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







    }
}
