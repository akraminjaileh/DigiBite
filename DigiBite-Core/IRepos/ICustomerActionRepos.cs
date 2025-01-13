using DigiBite_Core.DTOs.Address;
using DigiBite_Core.DTOs.Cart;
using DigiBite_Core.DTOs.CartItem;
using DigiBite_Core.DTOs.Order;
using DigiBite_Core.DTOs.Voucher;
using DigiBite_Core.Models.Entities;
using System.Linq.Expressions;

namespace DigiBite_Core.IRepos
{
    public interface ICustomerActionRepos
    {
        Task<decimal> CalculateSubtotal(int cartId);
        Task<decimal> GetAddonPrice(int id);
        Task<AddressDTO> GetAddressById(int id, string userId);
        Task<IEnumerable<AddressesDTO>> GetAddresses(string userId);
        Task<CartDTO> GetCartDetails(Expression<Func<Cart, bool>> predicate);
        Task<int> GetCartId(string userId);
        Task<AddressDTO> GetDefaultAddress(string userId);
        Task<OrderDetailsDTO> GetOrderDetails(int id);
        Task<IEnumerable<OrdersByDateDTO>> GetOrders(string userId);
        Task<ItemPriceDTO> GetPrice(int id, bool isMeal);
        Task<List<VoucherUserDTO>> GetUserVoucher(string userId);
        Task<bool> isCartOrdered(int cartItemId);
    }
}
