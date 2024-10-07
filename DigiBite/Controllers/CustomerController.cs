using DigiBite_Core.Constant;
using DigiBite_Core.DTOs.Account;
using DigiBite_Core.IServices;
using DigiBite_Core.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DigiBite_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(
        UserManager<AppUser> userManager,
        IMediaService mediaService
        ) : ControllerBase
    {


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
                user.LastModifiedDateTime = DateTime.UtcNow;

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

                var image = await mediaService.UploadFile(file, user.Id);
                user.ProfileImgId = image.Id;
                user.LastModifiedDateTime = DateTime.UtcNow;

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


    }
}
