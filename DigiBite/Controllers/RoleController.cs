using DigiBite_Core.Constant;
using DigiBite_Core.DTOs.Role;
using DigiBite_Core.Helpers;
using DigiBite_Core.IRepos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DigiBite_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController(RoleManager<IdentityRole> roleManager, ICommandRepos repos) : ControllerBase
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
                if (role.NormalizedName == Role.SuperAdmin.ToString().ToUpper())
                {
                    throw new Exception("Can't Update SuperAdmin Role");
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
                if (role.NormalizedName == Role.SuperAdmin.ToString().ToUpper())
                {
                    throw new Exception("Can't Delete SuperAdmin Role");
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

        #region Role Claim Management (Assign permissions to Role)

        /// <summary>
        /// Retrieves all RoleClaims.
        /// </summary>
        /// <returns>A list of RoleClaims.</returns>
        /// <response code="200">RoleClaim retrieved successfully.</response>
        /// <response code="404">No RoleClaim found.</response>
        /// <response code="400">Bad request.</response>
        [HttpGet]
        [Route("Roles/Claims")]
        [ProducesResponseType(typeof(ApiResponseSwagger<List<IdentityRoleClaim<bool>>>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        public async Task<IActionResult> GetRoleClaims(string roleName)
        {
            try
            {
                var role = await roleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    return NotFound($"Role {roleName} not found.");
                }
                var roleClaims = await roleManager.GetClaimsAsync(role);

                var claimsList = new List<Claim>();

                foreach (var claim in RoleClaim.Claims)
                    foreach (var roleClaim in roleClaims)
                    {
                        if (claim.Key == roleClaim.Type && claim.Value != roleClaim.Value)
                            claimsList.Add(new Claim(roleClaim.Type, roleClaim.Value));

                    }
                var unionClaim = claimsList.Select(x => new
                {
                    ClaimType = x.Type,
                    ClaimValue = x.Value
                });

                return Ok(unionClaim);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Retrieves all RoleClaims.
        /// </summary>
        /// <returns>A list of RoleClaims.</returns>
        /// <response code="200">RoleClaim retrieved successfully.</response>
        /// <response code="404">No RoleClaim found.</response>
        /// <response code="400">Bad request.</response>
        [HttpPost]
        [Route("Roles/Claims")]
        [ProducesResponseType(typeof(ApiResponseSwagger<List<IdentityRoleClaim<bool>>>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        public async Task<IActionResult> AddRoleClaims(List<CreateRoleClaimDTO> input, string roleId)
        {
            try
            {
                var role = await roleManager.FindByIdAsync(roleId);
                var claimsList = await roleManager.GetClaimsAsync(role);

                var roleClaims = new List<Claim>();
                foreach (var claim in input)
                {
                    roleClaims.Add(new Claim(claim.ClaimType, claim.ClaimValue));

                }

                //var result = await repos.AddRangAsync(roleClaims.Union(claimsList));
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Retrieves all RoleClaims.
        /// </summary>
        /// <returns>A list of RoleClaims.</returns>
        /// <response code="200">RoleClaim retrieved successfully.</response>
        /// <response code="404">No RoleClaim found.</response>
        /// <response code="400">Bad request.</response>
        [HttpDelete]
        [Route("Roles/Claims")]
        [ProducesResponseType(typeof(ApiResponseSwagger<List<IdentityRoleClaim<bool>>>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        public async Task<IActionResult> RemoveRolesClaim(string roleName)
        {
            try
            {
                var role = await roleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    return NotFound($"Role {roleName} not found.");
                }
                var roleClaim = await roleManager.GetClaimsAsync(role);

                return Ok(roleClaim);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}
