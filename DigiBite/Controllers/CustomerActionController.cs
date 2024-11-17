using DigiBite_Core.DTOs.Address;
using DigiBite_Core.DTOs.Cart;
using DigiBite_Core.DTOs.CartItem;
using DigiBite_Core.DTOs.Order;
using DigiBite_Core.DTOs.Voucher;
using DigiBite_Core.Helpers;
using DigiBite_Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DigiBite_Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Customer")]
    [ApiController]
    public class CustomerActionController(ICustomerActionService service) : ControllerBase
    {


        /// <summary>
        /// Retrieve Customer Addresses.
        /// </summary>
        /// <response code="200">Addresses retrieved successfully.</response>
        /// <response code="404">No Addresses found.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<AddressesDTO>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [HttpGet]
        [Route("Address")]
        public async Task<IActionResult> GetAddresses()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.GetAddresses(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retrieve Customer Address By Id.
        /// </summary>
        /// <response code="200">Address retrieved successfully.</response>
        /// <response code="404">No Address found.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<AddressDTO>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [HttpGet]
        [Route("Address/{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.GetAddressById(id, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Create Customer Address.
        /// </summary>
        /// <response code="200">Address Created successfully.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [HttpPost]
        [Route("Address")]
        public async Task<IActionResult> CreateAddress(CreateAddressDTO input)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.CreateAddress(input, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Update Customer Address.
        /// </summary>
        /// <response code="200">Address Updated successfully.</response>
        /// <response code="404">No Address found.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [HttpPut]
        [Route("Address/{id}")]
        public async Task<IActionResult> UpdateAddress(UpdateAddressDTO input, int id)
        {
            try
            {
                var result = await service.UpdateAddress(input, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Remove Customer Address.
        /// </summary>
        /// <response code="200">Address Removed successfully.</response>
        /// <response code="404">No Address found.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [HttpDelete]
        [Route("Address/{id}")]
        public async Task<IActionResult> RemoveAddress(int id)
        {
            try
            {
                var result = await service.RemoveAddress(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retrieve Current Cart.
        /// </summary>
        /// <response code="200">Retrieve Cart successfully.</response>
        /// <response code="404">No Cart found.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<CartDTO>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [HttpGet]
        [Route("Cart")]
        public async Task<IActionResult> GetActiveCart()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.GetActiveCart(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Add item to the cart and update cart prices. If no cart exists, a new one will be automatically created.if same item exists, a Quantity will be updated
        /// </summary>
        /// <response code="200">Add To Cart successfully.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddToCart(AddToCartDTO input)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.AddToCart(input,userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Remove Item From Cart and Update Cart Prices
        /// </summary>
        /// <param name="id">CartItem ID</param>
        /// <response code="200">Remove from Cart successfully.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.RemoveFromCart(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Update Item Quantity or Remove it if QTY less or equal to zero
        /// </summary>
        /// <response code="200">Update Quantity successfully.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateQuantity(UpdateQuantityDTO input)
        {
            try
            {
                var result = await service.UpdateQuantity(input.CartItemId, input.Qty);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Retrieve User Vouchers
        /// </summary>
        /// <response code="200">Retrieve Vouchers successfully.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<VoucherUserDTO>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [HttpGet]
        [Route("Voucher")]
        public async Task<IActionResult> GetVoucher()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.GetUserVoucher(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Apply Voucher and Update Cart Prices
        /// </summary>
        /// <param name="id">Voucher Id</param>
        /// <response code="200">Apply Voucher successfully.</response>
        /// <response code="404">No Voucher found.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [HttpPut]
        [Route("Voucher/{id}")]
        public async Task<IActionResult> ApplyVoucher(int id)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.ApplyVoucher(userId,id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Remove Voucher and Update Cart Prices
        /// </summary>
        /// <param name="id">Voucher Id</param>
        /// <response code="200">Remove Voucher successfully.</response>
        /// <response code="404">No Voucher found.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [HttpDelete]
        [Route("Voucher/{id}")]
        public async Task<IActionResult> RemoveVoucher(int id)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.RemoveVoucher(userId, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retrieve Customer Orders
        /// </summary>
        /// <response code="200">Retrieve Orders successfully.</response>
        /// <response code="404">No Orders found.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<OrdersDTO>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [HttpGet]
        [Route("Order")]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.GetOrders(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retrieve Order By Id
        /// </summary>
        /// <response code="200">Retrieve Order successfully.</response>
        /// <response code="404">No Order found.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<OrdersByDateDTO>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [HttpGet]
        [Route("Order/{id}")]
        public async Task<IActionResult> GetOrderDetails(int id)
        {
            try
            {
                var result = await service.GetOrderDetails(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Checkout Order and set Cart Status to ordered
        /// </summary>
        /// <param name="input">CreditCard,Cash,Wallet</param>
        /// <response code="200">Checkout Order successfully.</response>
        /// <response code="404">No Order found.</response>
        /// <response code="400">Bad request.</response>
        [ProducesResponseType(typeof(ApiResponseSwagger<int>), 200)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 404)]
        [ProducesResponseType(typeof(ApiResponseSwagger<string>), 400)]
        [HttpPost]
        [Route("Order/[action]")]
        public async Task<IActionResult> Checkout(CheckoutDTO input)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await service.Checkout(input,userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
