using DigiBite_Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DigiBite_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController(IMediaService service) : ControllerBase
    {
        [HttpPost]
        [Route("")]
        [Authorize]
        public async Task<IActionResult> UploadeFile([FromForm] IFormFileCollection files)
        {
            if (files == null)
                return BadRequest("Please choose a file");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok( await service.UploadFiles(files, userId));
        }
    }
}
