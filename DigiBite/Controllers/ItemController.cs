using DigiBite_Core.Helpers;
using DigiBite_Core.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigiBite_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController(IItemService service) : ControllerBase
    {
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetItems()
        {
            try
            {
                var items = await service.GetItems();
                return Ok(new ApiResponse(items));
            }
            catch (Exception ex)
            { 
                return BadRequest(new ApiResponse(ex.Message));
            }
        }
    }
}
