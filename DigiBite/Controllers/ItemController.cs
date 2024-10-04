using DigiBite_Core.Constant;
using DigiBite_Core.DTOs.Item;
using DigiBite_Core.Helpers;
using DigiBite_Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        [ProducesResponseType(typeof(ApiResponseSwagger<List<ItemsDTO>>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = "Item.Read")]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetItems(int skip, int take,[FromQuery] Dictionary<string, string>? orderBy, string? sortBy, bool isDescending)
        {
            try
            {
                var items = await service.GetItems(skip, take,orderBy,sortBy,isDescending);
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
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddItem(AddItemDTO input)
        {
            try
            {
                //var items = await service.GetItems(1, 2);
                return Ok();
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
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateItem(UpdateItemDTO input)
        {
            try
            {
                //var items = await service.GetItems(1, 2);
                return Ok();
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
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveItem(int id)
        {
            try
            {
                //var items = await service.GetItems(1, 2);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
