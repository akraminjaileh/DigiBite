using DigiBite_Core.DTOs.Account;
using DigiBite_Core.Helpers;
using DigiBite_Core.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DigiBite_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : ControllerBase
    {

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="input">The user details.</param>
        /// <returns>Action result indicating success or failure.</returns>
        /// <response code="201">Registration successful.</response>
        /// <response code="400">Bad request, e.g., phone number already taken.</response>
        /// <response code="500">Internal server error.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<AppUser>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> Signup(SignupDTO input)
        {
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

                var result = await userManager.CreateAsync(user, input.Password);

                return result.Succeeded ? StatusCode(201,"Registration Successfully")
                    : throw new Exception(result.Errors.First().Description);
            }
            catch (Exception ex)
            {
                if (ex.InnerException?.Message.Contains("IX_AspNetUsers_PhoneNumber") == true)
                {
                    return StatusCode(400,$"Phone '{input.PhoneNumber}' is already taken.");
                }
                return  StatusCode(500,ex.Message);
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
                    return StatusCode(200,"Login successful.");
                }
                else if (result.IsLockedOut)
                {
                    return StatusCode(423,"User account is locked.");
                }
                else if (result.IsNotAllowed)
                {
                    return StatusCode(403,"Login is not allowed.");
                }
                else
                {
                    return StatusCode(400,"Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500,$"Failed to login: {ex.Message}");
            }
        }

    }
}
