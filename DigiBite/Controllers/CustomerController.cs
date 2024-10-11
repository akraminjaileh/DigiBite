using DigiBite_Core.Constant;
using DigiBite_Core.DTOs.Account;
using DigiBite_Core.IServices;
using DigiBite_Core.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DigiBite_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(
        UserManager<AppUser> userManager,
        IMediaService mediaService
        ) : ControllerBase
    {


       


    }
}
