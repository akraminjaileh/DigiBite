using DigiBite_Core.Constant;
using DigiBite_Core.Entities.Lookups;
using Microsoft.AspNetCore.Mvc;

namespace DigiBite_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        [HttpPost]
       
        public async Task<IActionResult> FormTest([FromForm]IFormFileCollection images)
        {
            try
            {
                var imagesList = new List<Media>();

                foreach (var image in images)
                {
                    var media = new Media();

                    var fileExtension = image.FileName.Split('.').Last();
                    bool isParse = Enum.TryParse<FileType>(fileExtension, out var x);
                  
                    if (! isParse)
                        throw new Exception($"The file:'{image.FileName}' is not supported." +
                            $" Please choose one of these formats: {string.Join(", ", Enum.GetNames<FileType>())}");

                    

                }
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
