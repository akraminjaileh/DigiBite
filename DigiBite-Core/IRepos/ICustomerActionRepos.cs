using DigiBite_Core.DTOs.Address;
using DigiBite_Core.DTOs.Cart;
using DigiBite_Core.DTOs.CartItem;
using DigiBite_Core.DTOs.Voucher;

namespace DigiBite_Core.IRepos
{
    public interface ICustomerActionRepos
    {
        Task<decimal> CalculateSubtotal(int cartId);
        Task<CartDTO> GetActiveCart(string userId);
        Task<AddressDTO> GetAddressById(int id, string userId);
        Task<IEnumerable<AddressesDTO>> GetAddresses(string userId);
        Task<int> GetCartId(string userId);
        Task<ItemPriceDTO> GetPrice(int id, bool isMeal);
        Task<List<VoucherUserDTO>> GetUserVoucher(string userId);
    }
}
