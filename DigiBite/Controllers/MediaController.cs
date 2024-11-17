using DigiBite_Core.Constant;
using DigiBite_Core.DTOs.Media;
using DigiBite_Core.Helpers;
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


        /// <summary>
        /// Retrieve All Files.
        /// </summary>
        /// <response code="200">Files retrieved successfully.</response>
        /// <response code="404">No Files found.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<List<MediasDTO>>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.ImagePolicy.Read)]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetFiles(int skip, int take)
        {
            try
            {
                var result = await service.GetFiles(skip, take);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Upload Files.
        /// </summary>
        /// <response code="200">Files Uploaded successfully.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.ImagePolicy.Create)]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> UploadFiles([FromForm] IFormFileCollection files)
        {
            try
            {
                if (files == null)
                    return BadRequest("Please choose a files");
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                return Ok(await service.UploadFiles(files, userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Remove File.
        /// </summary>
        /// <response code="200">Files Removed successfully.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.ImagePolicy.Delete)]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveFile(int id)
        {
            try
            {
                var result = await service.RemoveFile(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Bulk Remove Files.
        /// </summary>
        /// <response code="200">Files Removed successfully.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.ImagePolicy.Delete)]
        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> BulkRemoveFile([FromBody] List<int> ids)
        {
            try
            {
                var result = await service.BulkRemoveFile(ids);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Update File.
        /// </summary>
        /// <response code="200">File Updated successfully.</response>
        /// <response code="404">No Files found.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.ImagePolicy.Update)]
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateFile([FromRoute]int id , MediaUpdateDTO input)
        {
            try
            {
                var result = await service.UpdateFile(id,input);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
