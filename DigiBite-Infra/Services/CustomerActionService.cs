using DigiBite_Core.Constant;
using DigiBite_Core.DTOs.Address;
using DigiBite_Core.DTOs.Cart;
using DigiBite_Core.DTOs.CartItem;
using DigiBite_Core.DTOs.Voucher;
using DigiBite_Core.Entities.ManyToMany;
using DigiBite_Core.IRepos;
using DigiBite_Core.IServices;
using DigiBite_Core.Models.Entities;
using DigiBite_Core.Models.Lookups;
using DigiBite_Core.Models.ManyToMany;

namespace DigiBite_Infra.Services
{
    public class CustomerActionService(ICommandRepos command, IQueryRepos query, ICustomerActionRepos repos) : ICustomerActionService
    {

        #region Addresses Service
        public async Task<IEnumerable<AddressesDTO>> GetAddresses(string userId)
        => await repos.GetAddresses(userId);

        public async Task<AddressDTO> GetAddressById(int id, string userId)
        => await repos.GetAddressById(id, userId);

        public async Task<int> CreateAddress(CreateAddressDTO input, string userId)
        {
            try
            {
                var address = new Address
                {
                    AdditionalDirection = input.AdditionalDirection,
                    Floor = input.Floor,
                    AddressLabel = input.AddressLabel,
                    Street = input.Street,
                    ApartmentNumber = input.ApartmentNumber,
                    BuildingName = input.BuildingName,
                    IsPrimary = input.IsPrimary,
                    Latitude = input.Latitude,
                    Longitude = input.Longitude,
                    UserId = userId
                };

                return await command.AddAsync(address);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> UpdateAddress(UpdateAddressDTO input, int id)
        {
            try
            {
                var address = await query.GetEntityAsync<Address>(x => x.Id == id);

                address.AdditionalDirection = input.AdditionalDirection ?? address.AdditionalDirection;
                address.Floor = input.Floor ?? address.Floor;
                address.AddressLabel = input.AddressLabel ?? address.AddressLabel;
                address.Street = input.Street ?? address.Street;
                address.ApartmentNumber = input.ApartmentNumber ?? address.ApartmentNumber;
                address.BuildingName = input.BuildingName ?? address.BuildingName;
                address.IsPrimary = input.IsPrimary ?? address.IsPrimary;
                address.Latitude = input.Latitude ?? address.Latitude;
                address.Longitude = input.Longitude ?? address.Longitude;

                return await command.UpdateAsync(address);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> RemoveAddress(int id)
        {
            try
            {
                var address = await query.GetEntityAsync<Address>(x => x.Id == id);
                address.IsActive = false;
                return await command.UpdateAsync(address);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Cart Service

        #region Cart Assest 
        private async Task<Cart> CreateNewCart(string userId)
        {
            try
            {
                var cart = new Cart
                {
                    CartStatus = CartStatus.Active,
                    CreatedAt = DateTime.Now,
                    UserId = userId,
                    DeliveryFee = 0,
                    Discount = 0,
                    ServiceFee = 0,
                    Subtotal = 0,
                    TotalAmount = 0,
                    VoucherDiscount = 0,
                    VoucherId = 0,
                };
                await command.AddAsync(cart);
                return cart;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> UpdateCart(int cartId)
        {
            try
            {
                var cart = await query.GetEntityAsync<Cart>(x => x.Id == cartId);
                cart.Subtotal = await repos.CalculateSubtotal(cart.Id);
                if (cart.Subtotal <= 0) return 0;
                cart.ServiceFee = Fees.ServiceFee * cart.Subtotal;
                cart.DeliveryFee = Fees.DeliveryFee;
                cart.TotalAmount = cart.Subtotal + cart.DeliveryFee + cart.ServiceFee - cart.VoucherDiscount;

                return await command.UpdateAsync(cart);

            }
            catch (Exception ex) { new Exception(ex.Message); }
        }
        #endregion

        public async Task<CartDTO> GetActiveCart(string userId)
       => await repos.GetActiveCart(userId);

        public async Task<int> AddToCart(AddToCartDTO input, string userId)
        {
            var transaction = await command.BeginTransactionAsync();
            try
            {
                if ((input.ItemId > 0 && input.MealId > 0)
                    || (input.ItemId == null && input.MealId == null)
                    || (input.ItemId == 0 && input.MealId == 0))
                    throw new Exception("Specify one of the IDs, either the mealId or the itemId");
                if (input.Quantity <= 0)
                    throw new Exception("The quantity must be greater than zero.");

                var cartItem = new CartItem();
                var activeCartId = await repos.GetCartId(userId);
                if (activeCartId == 0)
                {
                    var cart = await CreateNewCart(userId);
                    cartItem.CartId = cart.Id;
                }
                else cartItem.CartId = activeCartId;


                if (input.ItemId > 0)
                {
                    var item = await repos.GetPrice(input.ItemId ?? 0, false);
                    cartItem.ItemId = item.Id;
                    cartItem.ItemPrice = item.Price;
                }
                if (input.MealId > 0)
                {
                    var meal = await repos.GetPrice(input.MealId ?? 0, true);
                    cartItem.MealId = meal.Id;
                    cartItem.ItemPrice = meal.Price;
                }

                cartItem.Quantity = input.Quantity;
                cartItem.SpecialNotes = input.SpecialNotes;
                var result = await command.AddAsync(cartItem);
                await UpdateCart(cartItem.CartId);
                await transaction.CommitAsync();
                return result;

            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> RemoveFromCart(int cartItemId)
        {
            var transaction = await command.BeginTransactionAsync();
            try
            {
                var cartItem = await query.GetEntityAsync<CartItem>(x => x.Id == cartItemId);
                var cartId = cartItem.Id;
                var result = await command.RemovePermanentlyAsync(cartItem);
                await UpdateCart(cartId);
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<VoucherUserDTO>> GetUserVoucher(string userId)
            => await repos.GetUserVoucher(userId);

        public async Task<int> ApplyVoucher(string userId, int voucherId)
        {
            try
            {
                var voucher = await query.GetEntityAsync<Voucher>(v => v.Id == voucherId);
                if (voucher == null)
                    throw new Exception("Voucher not found");

                var userVoucher = await query.GetEntityAsync<VoucherUser>(x => x.UserId == userId && x.VoucherId == voucherId);
                if (userVoucher == null)
                    throw new Exception("Voucher does not apply to this user");

                if (voucher.ExpirationDate <= DateTime.Now)
                    throw new Exception("Voucher has expired.");

                if (voucher.ScheduleStartDate > DateTime.Now)
                    throw new Exception("Voucher is not yet valid.");

                if (voucher.IsActive == false)
                    throw new Exception("Voucher is not active.");

                if (voucher.MaxUsagesPerUser <= userVoucher.UsagesLeft)
                    throw new Exception("Voucher usage limit exceeded for this user.");

                var cart = await query.GetEntityAsync<Cart>(c => c.UserId == userId && c.CartStatus == CartStatus.Active);
                if (cart == null) throw new Exception("Can't Apply Voucher , the cart is ordered");

                if (voucher.MinimumOrderAmount < cart.Subtotal)
                    throw new Exception($"The cart does not meet the minimum order amount '{voucher.MinimumOrderAmount}' required for this voucher.");

                cart.VoucherId = voucher.Id;
                cart.VoucherDiscount = voucher.IsPercentage ? voucher.DiscountAmount * cart.Subtotal : voucher.DiscountAmount;
                return await command.UpdateAsync(cart);
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
            }
        }

        #endregion

    }
}
