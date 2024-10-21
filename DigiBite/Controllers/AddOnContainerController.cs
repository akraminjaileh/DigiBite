using DigiBite_Core.Constant;
using DigiBite_Core.DTOs.AddOn;
using DigiBite_Core.DTOs.AddOnContainer;
using DigiBite_Core.Helpers;
using DigiBite_Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DigiBite_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddOnContainerController(IAddOnService service) : ControllerBase
    {


        /// <summary>
        /// Retrieves all AddOnContainers.
        /// </summary>
        /// <response code="200">AddOnContainers retrieved successfully.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<List<AddOnContainersDTO>>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAddOnContainerContainers(int skip, int take, string? sortBy, bool isDescending)
        {
            try
            {
                var addons = await service.GetAddOnContainers(skip, take, sortBy, isDescending);
                return Ok(addons);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Retrieves AddOnContainer By Id.
        /// </summary>
        /// <param name="id">Container Id</param>
        /// <response code="200">AddOnContainer retrieved successfully.</response>
        /// <response code="404">No AddOnContainer found.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<AddOnContainerDTO>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAddOnContainerById([FromRoute] int id)
        {
            try
            {
                var addons = await service.GetAddOnContainerById(id);
                return addons is null ? NotFound("No AddOnContainer found.") : Ok(addons);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Create New AddOnContainer.
        /// </summary>
        /// <response code="200">AddOnContainer has been Created successfully.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.AddOnPolicy.Create)]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddAddOnContainer(CreateContainerWithAddOnDTO input)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.CreateContainerWithAddOn(input, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Update AddOnContainer.
        /// </summary>
        /// <param name="id">Container Id</param>
        /// <response code="200">AddOnContainer has been Updated successfully.</response>
        /// <response code="404">No AddOnContainer found to Update.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.AddOnPolicy.Update)]
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAddOnContainer(UpdateContainerDTO input, int id)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.UpdateContainer(id,input, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Delete AddOnContainer set IsActive Flag to False.
        /// </summary>
        /// <param name="id">Container Id</param>
        /// <response code="200">AddOnContainer has been Deleted successfully.</response>
        /// <response code="404">No AddOnContainer found to Deleted.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.AddOnPolicy.Delete)]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveAddOnContainer(int id)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.RemoveAddOnContainer(id, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Bulk Delete AddOnContainers set IsActive Flag to False.
        /// </summary>
        /// <response code="200">AddOnContainers has been Deleted successfully.</response>
        /// <response code="404">No AddOnContainers found to Deleted.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.AddOnPolicy.Delete)]
        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> BulkRemoveAddOnContainer([FromBody] List<int> addonIDs)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.BulkRemoveAddOnContainer(addonIDs, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        /// <summary>
        /// Create New AddOn to specific Container.
        /// </summary>
        /// <param name="id">Container Id</param>
        /// <response code="200">AddOn has been Created successfully.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.AddOnPolicy.Create)]
        [HttpPost]
        [Route("Addon/{id}")]
        public async Task<IActionResult> NewAddOn(int id, NewAddOnDTO input)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.NewAddOn(id, input, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Update AddOn Images.
        /// </summary>
        /// <param name="id">AddOn Id</param>
        /// <response code="200">Images has been Updated successfully.</response>
        /// <response code="404">No AddOn found to Update.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.AddOnPolicy.Update)]
        [HttpPut]
        [Route("Addon/{id}")]
        public async Task<IActionResult> UpdateAddOnImages(int id, int imageId)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.UpdateAddOnImage(id, imageId, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Delete AddOn set IsActive Flag to False.
        /// </summary>
        /// <param name="id">AddOn Id</param>
        /// <response code="200">AddOn has been Deleted successfully.</response>
        /// <response code="404">No AddOn found to Deleted.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.AddOnPolicy.Delete)]
        [HttpDelete]
        [Route("Addon/{id}")]
        public async Task<IActionResult> RemoveAddOn([FromRoute]int id)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.RemoveAddOn(id,userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
