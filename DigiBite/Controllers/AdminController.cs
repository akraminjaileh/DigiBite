using DigiBite_Core.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net;

namespace DigiBite_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly RoleManager<IdentityRole> roleManager;

        public AdminController(RoleManager<IdentityRole> roleManager
          )
        {
            this.roleManager = roleManager;

        }

        #region Role Management


        [HttpGet]
        [Route("Role")]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                var roles = await roleManager.Roles.ToListAsync();
                if (roles is null)
                {
                    throw new Exception($"No Roles Found");
                }
                return Ok(new ApiResponse<IdentityRole>(roles));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Role/{id}")]
        public async Task<IActionResult> GetRolesById([FromRoute] string id)
        {
            try
            {
                var role = await roleManager.FindByIdAsync(id);
                if (role is null)
                {
                    throw new Exception($"Role with id : {id} is  Not Found");

                }
                return Ok(new ApiResponse<IdentityRole>(role));
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<IdentityRole>(ex.Message));
            }



        }

        //[HttpPost]
        //[Route("Role")]
        //public async Task<IActionResult> AddRole(string name)
        //{
        //    try
        //    {
        //        var role = await roleManager.FindByNameAsync(name);
        //        if (role != null)
        //        {
        //            throw new Exception($"The Role Name : {name} is Existing");
        //        }
        //        await roleManager.CreateAsync(new IdentityRole { Name = name });
        //        return Ok("The Role has been Created Successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpPut]
        //[Route("Role/{id}")]
        //public async Task<IActionResult> UpdateRole([FromRoute] string id, string name)
        //{
        //    try
        //    {
        //        var role = await roleManager.FindByIdAsync(id);
        //        if (role is null)
        //        {
        //            throw new Exception("Role Id Not Exist");
        //        }
        //        bool isDefault = false;
        //        var roleNames = Enum.GetNames<DefaultRole>();
        //        foreach (var roleName in roleNames)
        //        {
        //            if (roleName == name)
        //            {
        //                isDefault = true;
        //            }
        //        }
        //        if (isDefault)
        //        {
        //            throw new Exception("Can't Update or Delete Default Role");
        //        }
        //        role.Name = name;
        //        await roleManager.UpdateAsync(role);
        //        return Ok($"The Role {role.Name} has been Updated to {name} Successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpDelete]
        //[Route("Role")]
        //public async Task<IActionResult> RemoveRole(string name)
        //{
        //    try
        //    {
        //        var role = roleManager.Roles.FirstOrDefault(x => x.Name == name);
        //        if (role is null)
        //        {
        //            throw new Exception("Role Name Not Exist");
        //        }
        //        await roleManager.DeleteAsync(role);
        //        return Ok("The Role has been Deleted Successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //}

        #endregion


    }
}
