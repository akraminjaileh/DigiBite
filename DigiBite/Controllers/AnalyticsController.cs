using DigiBite_Core.DTOs.Analytics;
using DigiBite_Core.DTOs.Category;
using DigiBite_Core.Helpers;
using DigiBite_Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DigiBite_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticsController(IAnalyticsService service) : ControllerBase
    {


        /// <summary>
        /// Retrieves Daily Sales.
        /// </summary>
        /// <response code="200">Daily Sales retrieved successfully.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<SalesDataDTO>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [HttpGet]
        [Route("DailySales")]
        public async Task<IActionResult> GetDailySales()
        {
            try
            {
                return Ok(await service.GetDailySales());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves Monthly Sales.
        /// </summary>
        /// <response code="200">Monthly Sales retrieved successfully.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<SalesDataDTO>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [HttpGet]
        [Route("MonthlySales")]
        public async Task<IActionResult> GetMonthlySales()
        {
            try
            {
                return Ok(await service.GetMonthlySales());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
