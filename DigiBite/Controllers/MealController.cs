using DigiBite_Core.DTOs.Meal;
using DigiBite_Core.Helpers;
using DigiBite_Core.IServices;
using Microsoft.AspNetCore.Mvc;

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
        [ProducesResponseType(typeof(ApiResponseSwagger<List<MealDTO>>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetMeals(int skip, int take)
        {
            try
            {
                var Meals = await service.GetMeals(skip, take);
                return Ok(Meals);
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
        [ProducesResponseType(typeof(ApiResponseSwagger<MealDTO>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetMealById([FromRoute] int id)
        {
            try
            {
                var Meals = await service.GetMeals(1, 2);
                return Ok(Meals);
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
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddMeal(AddMealDTO input)
        {
            try
            {
                var Meals = await service.GetMeals(1, 2);
                return Ok(Meals);
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
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateMeal(UpdateMealDTO input)
        {
            try
            {
                var Meals = await service.GetMeals(1, 2);
                return Ok(Meals);
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
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveMeal(int id)
        {
            try
            {
                var Meals = await service.GetMeals(1, 2);
                return Ok(Meals);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
