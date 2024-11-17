using DigiBite_Core.Constant;
using DigiBite_Core.DTOs.Voucher;
using DigiBite_Core.Helpers;
using DigiBite_Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DigiBite_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController(IVoucherService service) : ControllerBase
    {


        /// <summary>
        /// Retrieves all Vouchers.
        /// </summary>
        /// <response code="200">Vouchers retrieved successfully.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<List<VouchersDTO>>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.VoucherPolicy.Read)]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetVouchers(int skip, int take, [FromQuery] Dictionary<string, string>? orderBy, string? sortBy, bool isDescending)
        {
            try
            {
                return Ok( await service.GetVouchers(skip, take, orderBy, sortBy, isDescending));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Retrieves Voucher By Id.
        /// </summary>
        /// <response code="200">Voucher retrieved successfully.</response>
        /// <response code="404">No Voucher found.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<VoucherDTO>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.VoucherPolicy.Read)]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetVoucherById([FromRoute] int id)
        {
            try
            {
                var v = await service.GetVoucher(id);
                return v is null ? NotFound("No Voucher found.") : Ok(v);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Create New Voucher.
        /// </summary>
        /// <response code="200">Voucher has been Created successfully.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.VoucherPolicy.Create)]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddVoucher(CreateVoucherDTO input)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.CreateVoucher(input, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Update Voucher.
        /// </summary>
        /// <response code="200">Voucher has been Updated successfully.</response>
        /// <response code="404">No Voucher found to Update.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.VoucherPolicy.Update)]
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateVoucher(UpdateVoucherDTO input, int id)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.UpdateVoucher(id, input, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Delete Voucher set IsActive Flag to False.
        /// </summary>
        /// <response code="200">Voucher has been Deleted successfully.</response>
        /// <response code="404">No Voucher found to Deleted.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.VoucherPolicy.Delete)]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveVoucher(int id)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.RemoveVoucher(id, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Assign Voucher To Multi User
        /// </summary>
        /// <response code="200">Voucher has been Assigned successfully.</response>
        /// <response code="404">No Voucher found to Assign.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [Authorize(Policy = RoleClaim.VoucherPolicy.Create)]
        [HttpPost]
        [Route("{voucherId}")]
        public async Task<IActionResult> AssignVoucherToUser([FromBody]List<string> userIds,[FromRoute]int voucherId)
        {
            try
            {
                var result = await service.AssignVoucherToUser(userIds,voucherId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
