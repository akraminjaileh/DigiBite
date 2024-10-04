using DigiBite_Core.Constant;
using DigiBite_Core.Context;
using DigiBite_Core.DTOs.Role;
using DigiBite_Core.Helpers;
using DigiBite_Core.IRepos;
using DigiBite_Core.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;

namespace DigiBite_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController(
        RoleManager<IdentityRole> roleManager,
        ICommandRepos command,
        DigiBiteContext context,
        UserManager<AppUser> userManager
        ) : ControllerBase
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
        [Route("")]
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
        [Route("{id}")]
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
        [Route("")]
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
        [Route("{id}")]
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
                var tempName = role.Name;
                role.Name = name;
                role.NormalizedName = name.ToUpper();

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
        /// Deletes a role by ID with its associated permissions.
        /// </summary>
        /// <param name="id">The role ID.</param>
        /// <returns>Action result indicating success or failure.</returns>
        /// <response code="200">Role deleted successfully.</response>
        /// <response code="400">Bad request, e.g., role does not exist or cannot be deleted.</response>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        public async Task<IActionResult> RemoveRole([FromRoute] string id)
        {
            var transaction = await context.Database.BeginTransactionAsync();
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
                var claimsList = await context.RoleClaims.Where(x => x.RoleId == role.Id).ToListAsync();

                if (!claimsList.IsNullOrEmpty())
                    await command.RemoveRangPermanentlyAsync(claimsList);

                await transaction.CommitAsync();

                return result.Succeeded ?
                    Ok($"The Role '{tempName}' has been Deleted Successfully with its associated Permissions")
                    : throw new Exception(result.Errors.First().Description);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Role Claim Management (Assign permissions to Role)

        /// <summary>
        /// Retrieves all Permission By Role ID.
        /// </summary>
        /// <param name="roleId">Role ID</param>
        /// <response code="200">RoleClaim retrieved successfully.</response>
        /// <response code="404">Role not found.</response>
        /// <response code="400">Bad request.</response>
        [HttpGet]
        [Route("Permission")]
        [ProducesResponseType(typeof(ApiResponseSwagger<IEnumerable<KeyValuePair<string, string>>>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        public async Task<IActionResult> GetRoleClaims(string roleId)
        {
            try
            {
                var role = await roleManager.FindByIdAsync(roleId);
                if (role == null)
                {
                    return NotFound($"Role with Id :'{roleId}' not found.");
                }
                var roleClaims = await roleManager.GetClaimsAsync(role);

                var claimList = roleClaims
                        .ToDictionary(x => x.Type, x => x.Value)
                        .UnionBy(RoleClaim.Claims, c => c.Key);

                return Ok(claimList);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Add or Remove Permission to Role
        /// </summary>
        /// <param name="inputs">Like:[{"Key": "Item.Read","Value": "true"},{"Key": "Item.Create","Value": "true"}]</param>
        /// <param name="roleId">Role Id</param>
        /// <response code="200">Return Permission Access for Role</response>
        /// <response code="404">No RoleClaim found.</response>
        /// <response code="400">Bad request.</response>
        [HttpPost]
        [Route("Permission")]
        [ProducesResponseType(typeof(ApiResponseSwagger<List<CreateRoleClaimDTO>>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        public async Task<IActionResult> AddOrRemoveRoleClaims(List<CreateRoleClaimDTO> inputs, string roleId)
        {
            var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                if (inputs.IsNullOrEmpty())
                    return NotFound("No Permission Selected");

                var role = await roleManager.FindByIdAsync(roleId);

                if (role == null)
                    return NotFound($"Role by Id {roleId} Not Found");

                if (role.NormalizedName == Role.SuperAdmin.ToString().ToUpper())
                    throw new Exception("Can't Add or Remove Permission to SuperAdmin");


                var claimsList = await context.RoleClaims.Where(x => x.RoleId == role.Id).ToListAsync();

                if (!claimsList.IsNullOrEmpty())
                    await command.RemoveRangPermanentlyAsync(claimsList);

                var newList = new List<IdentityRoleClaim<string>>();
                foreach (var input in inputs)
                {
                    if (input.Value.ToLower() == "true")
                        newList.Add(new IdentityRoleClaim<string>
                        {
                            RoleId = roleId,
                            ClaimType = input.Key,
                            ClaimValue = input.Value.ToLower()
                        });
                }
                var result = await command.AddRangAsync(newList);
                await transaction.CommitAsync();

                return Ok($"'{result}' Permission has been added");

            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return BadRequest(ex.Message);
            }
        }


        #endregion

        #region Assign Role to User

        /// <summary>
        /// Assigns or Remove multiple roles to a user.
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="roleNames">If you don't include the user's current roles in the list, those roles will be removed.</param>
        /// <response code="200">Roles assigned to user successfully.</response>
        /// <response code="404">User or one of the roles not found</response>
        /// <response code="400">Bad request.</response>
        [HttpPost]
        [Route("AssignUserRoles")]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        public async Task<IActionResult> AssignRoleUser(string userId, IEnumerable<string> roleNames)
        {
            var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                if (roleNames.Any(r => r.ToUpper() == Role.SuperAdmin.ToString().ToUpper()))
                    return BadRequest("Cannot assign the SuperAdmin role to a user.");

                var user = await userManager.FindByIdAsync(userId);
                if (user == null)
                    return NotFound($"User with ID '{userId}' not found.");

                var userRole = await userManager.GetRolesAsync(user);
                if (userRole.Any(r => r.ToUpper() == Role.SuperAdmin.ToString().ToUpper()))
                    return BadRequest("Cannot assign or remove any role to the SuperAdmin. The SuperAdmin already has full access.");

                foreach (var roleName in roleNames)
                {
                    var roleExists = await roleManager.RoleExistsAsync(roleName);
                    if (!roleExists)
                        return NotFound($"Role '{roleName}' does not exist.");
                }
                string temp = "";
                if (!userRole.IsNullOrEmpty())
                {
                    temp = $"{string.Join(",", userRole.Except(roleNames, StringComparer.OrdinalIgnoreCase))}";
                    temp = temp.IsNullOrEmpty() ? "" : $", and the following roles were removed: '{temp}'";
                    await userManager.RemoveFromRolesAsync(user, userRole);
                }

                var result = await userManager.AddToRolesAsync(user, roleNames);


                if (result.Succeeded)
                {
                    await transaction.CommitAsync();
                    return Ok($"Roles '{string.Join(", ", roleNames)}'" +
                        $" assigned to user '{user.UserName}' successfully{temp}");
                }

                return BadRequest($"Failed to assign roles to user '{user.UserName}': {result.Errors.First().Description}");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        #endregion

    }
}
