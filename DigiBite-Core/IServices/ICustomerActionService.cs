using DigiBite_Core.DTOs.Address;
using DigiBite_Core.DTOs.Cart;
using DigiBite_Core.DTOs.CartItem;
using DigiBite_Core.DTOs.Order;
using DigiBite_Core.DTOs.Voucher;

namespace DigiBite_Core.IServices
{
    public interface ICustomerActionService
    {
        Task<IEnumerable<AddressesDTO>> GetAddresses(string userId);
        Task<AddressDTO> GetAddressById(int id, string userId);
        Task<int> CreateAddress(CreateAddressDTO input, string userId);
        Task<int> UpdateAddress(UpdateAddressDTO input, int id);
        Task<int> RemoveAddress(int id);
        //Cart
        Task<CartDTO> GetActiveCart(string userId);
        Task<int> AddToCart(AddToCartDTO input, string userId);
        Task<int> RemoveFromCart(int cartItemId);
        Task<List<VoucherUserDTO>> GetUserVoucher(string userId);
        Task<int> ApplyVoucher(string userId, int voucherId);
        Task<int> RemoveVoucher(string userId, int voucherId);
        Task<IEnumerable<OrdersByDateDTO>> GetOrders(string userId);
        Task<OrderDetailsDTO> GetOrderDetails(int id);
        Task<int> Checkout(CheckoutDTO input, string userId);
        Task<int> UpdateQuantity(int cartItemId, int qty);
    }
}
