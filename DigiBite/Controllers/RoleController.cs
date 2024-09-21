using DigiBite_Core.Enums;
using DigiBite_Core.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigiBite_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController(RoleManager<IdentityRole> roleManager) : ControllerBase
    {

        #region Role Management
        /// <summary>
        /// Retrieves all roles.
        /// </summary>
        /// <returns>A list of roles.</returns>
        /// <response code="200">Roles retrieved successfully.</response>
        /// <response code="404">No roles found.</response>
        /// <response code="400">Bad request.</response>
        [HttpGet]
        [Route("Roles")]
        [ProducesResponseType(typeof(ApiResponseSwagger<List<IdentityRole>>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                var roles = await roleManager.Roles.ToListAsync();

                return roles is null ? NotFound("No Roles Found") : Ok(roles);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves a role by ID.
        /// </summary>
        /// <param name="id">The role ID.</param>
        /// <returns>The role details.</returns>
        /// <response code="200">Role retrieved successfully.</response>
        /// <response code="404">Role not found.</response>
        /// <response code="400">Bad request.</response>
        [HttpGet]
        [Route("Roles/{id}")]
        [ProducesResponseType(typeof(ApiResponseSwagger<IdentityRole>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        public async Task<IActionResult> GetRoleById([FromRoute] string id)
        {
            try
            {
                var role = await roleManager.FindByIdAsync(id);

                return role is null ? NotFound($"Role with id : {id} is  Not Found") : Ok(role);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Adds a new role.
        /// </summary>
        /// <param name="name">The name of the role.</param>
        /// <returns>Action result indicating success or failure.</returns>
        /// <response code="200">Role created successfully.</response>
        /// <response code="400">Bad request, e.g., role name already exists.</response>
        [HttpPost]
        [Route("Role")]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        public async Task<IActionResult> AddRole(string name)
        {
            try
            {
                var role = await roleManager.FindByNameAsync(name);
                if (role != null)
                {
                    throw new Exception($"The Role Name : {name} is Existing");
                }
                var result = await roleManager.CreateAsync(new IdentityRole { Name = name });

                return result.Succeeded ?
                    Ok("The Role has been Created Successfully")
                    : throw new Exception(result.Errors.First().Description);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Updates an existing role.
        /// </summary>
        /// <param name="id">The role ID.</param>
        /// <param name="name">The new role name.</param>
        /// <returns>Action result indicating success or failure.</returns>
        /// <response code="200">Role updated successfully.</response>
        /// <response code="400">Bad request, e.g., role does not exist or invalid update.</response>
        [HttpPut]
        [Route("Roles/{id}")]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        public async Task<IActionResult> UpdateRole([FromRoute] string id, string name)
        {
            try
            {
                var role = await roleManager.FindByIdAsync(id);
                if (role is null)
                {
                    throw new Exception("The Role is Not Exist");
                }
                if (role.NormalizedName == Role.Owner.ToString().ToUpper())
                {
                    throw new Exception("Can't Update Owner Role");
                }
                role.Name = name;
                role.NormalizedName = name.ToUpper();

                var tempName = role.Name;

                var result = await roleManager.UpdateAsync(role);

                return result.Succeeded ?
                    Ok($"The Role '{tempName}' has been Updated to '{name}' Successfully")
                    : throw new Exception(result.Errors.First().Description);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletes a role by ID.
        /// </summary>
        /// <param name="id">The role ID.</param>
        /// <returns>Action result indicating success or failure.</returns>
        /// <response code="200">Role deleted successfully.</response>
        /// <response code="400">Bad request, e.g., role does not exist or cannot be deleted.</response>
        [HttpDelete]
        [Route("Roles/{id}")]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        public async Task<IActionResult> RemoveRole([FromRoute] string id)
        {
            try
            {
                var role = await roleManager.FindByIdAsync(id);
                if (role is null)
                {
                    throw new Exception("The Role is Not Exist");
                }
                if (role.NormalizedName == Role.Owner.ToString().ToUpper())
                {
                    throw new Exception("Can't Delete Owner Role");
                }
                var tempName = role.Name;
                var result = await roleManager.DeleteAsync(role);

                return result.Succeeded ?
                    Ok($"The Role '{tempName}' has been Deleted Successfully")
                    : throw new Exception(result.Errors.First().Description);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Role Claim Management


        #endregion
    }
}
