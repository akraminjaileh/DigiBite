using DigiBite_Core.Constant;
using DigiBite_Core.DTOs.Category;
using DigiBite_Core.Helpers;
using DigiBite_Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DigiBite_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategoryService service) : ControllerBase
    {


        /// <summary>
        /// Retrieves all Categories.
        /// </summary>
        /// <response code="200">Categories retrieved successfully.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<List<CategoryDTO>>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var cats = await service.GetCategories();
                return Ok(cats);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Retrieves Category By Id.
        /// </summary>
        /// <response code="200">Category retrieved successfully.</response>
        /// <response code="404">No Category found.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<CategoryDetailsDTO>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
            try
            {
                var cats = await service.GetCategoryDetails(id);
                return cats is null ? NotFound("No Category found.") : Ok(cats);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Create New Category.
        /// </summary>
        /// <response code="200">Category has been Created successfully.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.CategoryPolicy.Create)]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddCategory(AddCategoryDTO input)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.AddCategory(input, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Update Category.
        /// </summary>
        /// <response code="200">Category has been Updated successfully.</response>
        /// <response code="404">No Category found to Update.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.CategoryPolicy.Update)]
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDTO input, int id)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.UpdateCategory(id, input, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Update Category Images.
        /// </summary>
        /// <response code="200">Images has been Updated successfully.</response>
        /// <response code="404">No Category found to Update.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.CategoryPolicy.Update)]
        [HttpPut]
        [Route("file")]
        public async Task<IActionResult> UpdateCategoryImages(int catId, int imageId)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.UpdateCategoryImage(catId, imageId, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Delete Category set IsActive Flag to False.
        /// </summary>
        /// <response code="200">Category has been Deleted successfully.</response>
        /// <response code="404">No Category found to Deleted.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.CategoryPolicy.Delete)]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.RemoveCategory(id, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
