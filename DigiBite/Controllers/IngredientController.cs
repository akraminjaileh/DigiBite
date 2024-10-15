using DigiBite_Core.Constant;
using DigiBite_Core.DTOs.Ingredient;
using DigiBite_Core.Helpers;
using DigiBite_Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DigiBite_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController(IIngredientService service) : ControllerBase
    {

        /// <summary>
        /// Retrieves all Ingredients.
        /// </summary>
        /// <response code="200">Ingredients retrieved successfully.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<List<IngredientsWithImageDTO>>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetIngredients(int skip, int take, string? sortBy, bool isDescending)
        {
            try
            {
                var ingredients = await service.GetIngredients(skip, take, sortBy, isDescending);
                return Ok(ingredients);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Retrieves Ingredient By Id.
        /// </summary>
        /// <response code="200">Ingredient retrieved successfully.</response>
        /// <response code="404">No Ingredient found.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<IngredientsWithImageDTO>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetIngredientById([FromRoute] int id)
        {
            try
            {
                var ingredients = await service.GetIngredientDetails(id);
                return ingredients is null ? NotFound("No Ingredient found.") : Ok(ingredients);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Create New Ingredient.
        /// </summary>
        /// <response code="200">Ingredient has been Created successfully.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.IngredientPolicy.Create)]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddIngredient(AddIngredientDTO input)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.AddIngredient(input, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Update Ingredient.
        /// </summary>
        /// <response code="200">Ingredient has been Updated successfully.</response>
        /// <response code="404">No Ingredient found to Update.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.IngredientPolicy.Update)]
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateIngredient(AddIngredientDTO input, int id)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.UpdateIngredient(id, input, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Update Ingredient Images.
        /// </summary>
        /// <response code="200">Images has been Updated successfully.</response>
        /// <response code="404">No Ingredient found to Update.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.IngredientPolicy.Update)]
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateIngredientImages(int imageId, int ingredientId)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.UpdateIngredientImage(ingredientId, imageId, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Delete Ingredient set IsActive Flag to False.
        /// </summary>
        /// <response code="200">Ingredient has been Deleted successfully.</response>
        /// <response code="404">No Ingredient found to Deleted.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.IngredientPolicy.Delete)]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveIngredient(int id)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.RemoveIngredient(id, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Bulk Delete Ingredients set IsActive Flag to False.
        /// </summary>
        /// <response code="200">Ingredients has been Deleted successfully.</response>
        /// <response code="404">No Ingredients found to Deleted.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.IngredientPolicy.Delete)]
        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> BulkRemoveIngredient([FromBody] List<int> ingredientIDs)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.BulkRemoveIngredient(ingredientIDs, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
