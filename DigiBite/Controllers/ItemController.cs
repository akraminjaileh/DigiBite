using DigiBite_Core.Constant;
using DigiBite_Core.DTOs.Item;
using DigiBite_Core.Helpers;
using DigiBite_Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DigiBite_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController(IItemService service) : ControllerBase
    {

        /// <summary>
        /// Retrieves all Items.
        /// </summary>
        /// <response code="200">Items retrieved successfully.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<PaginatedResult<ItemsDTO>>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetItems(int skip, int take, [FromQuery] Dictionary<string, string>? orderBy, string? sortBy, bool isDescending)
        {
            try
            {
                var items = await service.GetItems(skip, take, orderBy, sortBy, isDescending);
                return Ok(items);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Retrieves Item By Id.
        /// </summary>
        /// <response code="200">Item retrieved successfully.</response>
        /// <response code="404">No Item found.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<ItemDetailsDTO>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetItemById([FromRoute] int id)
        {
            try
            {
                var items = await service.GetItemDetails(id);
                return items is null ? NotFound("No Item found.") : Ok(items);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Create New Item.
        /// </summary>
        /// <response code="200">Item has been Created successfully.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.ItemPolicy.Create)]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddItem(AddItemDTO input)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.AddItemWithDetails(input, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Update Item.
        /// </summary>
        /// <response code="200">Item has been Updated successfully.</response>
        /// <response code="404">No Item found to Update.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.ItemPolicy.Update)]
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateItem(UpdateItemDTO input, int id)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.UpdateItemWithDetails(input, userId, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Update Item Images.
        /// </summary>
        /// <response code="200">Images has been Updated successfully.</response>
        /// <response code="404">No Item found to Update.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.ItemPolicy.Update)]
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateItemImages(List<ItemImagesDTO> input, int itemId)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.UpdateItemImages(itemId, input, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Delete Item set IsActive Flag to False.
        /// </summary>
        /// <response code="200">Item has been Deleted successfully.</response>
        /// <response code="404">No Item found to Deleted.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.ItemPolicy.Delete)]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveItem(int id)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.RemoveItem(id, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Bulk Delete Items set IsActive Flag to False.
        /// </summary>
        /// <response code="200">Items has been Deleted successfully.</response>
        /// <response code="404">No Items found to Deleted.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.ItemPolicy.Delete)]
        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> BulkRemoveItem([FromBody] List<int> itemIDs)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.BulkRemoveItem(itemIDs, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
