using DigiBite_Core.Constant;
using DigiBite_Core.DTOs.Item;
using DigiBite_Core.DTOs.Meal;
using DigiBite_Core.Helpers;
using DigiBite_Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DigiBite_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController(IMealService service) : ControllerBase
    {

        /// <summary>
        /// Retrieves all Meals.
        /// </summary>
        /// <response code="200">Meals retrieved successfully.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<List<MealsDTO>>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetMeals(int skip, int take, [FromQuery] Dictionary<string, string>? orderBy, string? sortBy, bool isDescending)
        {
            try
            {
                var meals = await service.GetMeals(skip, take, orderBy, sortBy, isDescending);
                return Ok(meals);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Retrieves Meal By Id.
        /// </summary>
        /// <response code="200">Meal retrieved successfully.</response>
        /// <response code="404">No Meal found.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<MealDetailsDTO>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetMealById([FromRoute] int id)
        {
            try
            {
                var meals = await service.GetMealDetails(id);
                return meals is null ? NotFound("No Meal found.") : Ok(meals);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Create New Meal.
        /// </summary>
        /// <response code="200">Meal has been Created successfully.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.MealPolicy.Create)]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddMeal(AddMealDTO input)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.AddMealWithDetails(input, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Update Meal.
        /// </summary>
        /// <response code="200">Meal has been Updated successfully.</response>
        /// <response code="404">No Meal found to Update.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.MealPolicy.Update)]
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateMeal(UpdateMealDTO input, int id)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.UpdateMealWithDetails(input, userId, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Update Meal Images.
        /// </summary>
        /// <response code="200">Images has been Updated successfully.</response>
        /// <response code="404">No Meal found to Update.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.MealPolicy.Update)]
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateMealImages(List<ItemImagesDTO> input, int mealId)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.UpdateMealImages(mealId, input, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Delete Meal set IsActive Flag to False.
        /// </summary>
        /// <response code="200">Meal has been Deleted successfully.</response>
        /// <response code="404">No Meal found to Deleted.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.MealPolicy.Delete)]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveMeal(int id)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.RemoveMeal(id, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Bulk Delete Meals set IsActive Flag to False.
        /// </summary>
        /// <response code="200">Meals has been Deleted successfully.</response>
        /// <response code="404">No Meals found to Deleted.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.MealPolicy.Delete)]
        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> BulkRemoveMeal([FromBody] List<int> mealIDs)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.BulkRemoveMeal(mealIDs, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
