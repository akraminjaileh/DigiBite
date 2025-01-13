using DigiBite_Core.Constant;
using DigiBite_Core.DTOs.Address;
using DigiBite_Core.DTOs.Cart;
using DigiBite_Core.DTOs.CartItem;
using DigiBite_Core.DTOs.Order;
using DigiBite_Core.DTOs.Voucher;
using DigiBite_Core.Entities.ManyToMany;
using DigiBite_Core.IRepos;
using DigiBite_Core.IServices;
using DigiBite_Core.Models.Entities;
using DigiBite_Core.Models.Lookups;
using DigiBite_Core.Models.ManyToMany;
using Microsoft.IdentityModel.Tokens;

namespace DigiBite_Infra.Services
{
    public class CustomerActionService(ICommandRepos command, IQueryRepos query, ICustomerActionRepos repos) : ICustomerActionService
    {

        #region Addresses Service
        public async Task<IEnumerable<AddressesDTO>> GetAddresses(string userId)
        => await repos.GetAddresses(userId);
        public async Task<AddressDTO> GetDefaultAddress(string userId)
            => await repos.GetDefaultAddress(userId);
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
                    IsActive = true,
                    Latitude = input.Latitude,
                    Longitude = input.Longitude,
                    UserId = userId
                };

                if (input.IsPrimary == true)
                {
                    var temp = await query.GetEntitiesAsync<Address>(x => x.UserId == userId && x.IsActive == true && x.IsPrimary == true);
                    foreach (var t in temp)
                    {
                        t.IsPrimary = false;
                    }
                    await command.UpdateRangAsync(temp);
                }

                return await command.AddAsync(address);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> UpdateAddress(UpdateAddressDTO input, int id, string userId)
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

                if (input.IsPrimary == true)
                {
                    var temp = await query.GetEntitiesAsync<Address>(x => x.UserId == userId && x.IsActive == true && x.IsPrimary == true);
                    foreach (var t in temp)
                    {
                        t.IsPrimary = false;
                    }
                    await command.UpdateRangAsync(temp);
                }

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
                    VoucherId = null,
                };
                await command.AddAsync(cart);
                return cart;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private async Task<int> UpdateCart(int cartId)
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
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        #endregion

        public async Task<CartDTO> GetActiveCart(string userId)
       => await repos.GetCartDetails(x => x.UserId == userId && x.CartStatus == CartStatus.Active);

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

                var cartItems = await query.GetEntitiesAsync<CartItem>(
                       x =>
                       x.CartId == cartItem.CartId
                       && x.ItemPrice == cartItem.ItemPrice
                       && ((x.ItemId == input.ItemId) || (x.MealId == input.MealId))
                       && x.SpecialNotes.Equals(input.SpecialNotes));
                if (!cartItems.IsNullOrEmpty())
                {
                    foreach (var ci in cartItems)
                    {
                        if (input.CartItemAddonIDs != null && input.CartItemAddonIDs.All(x => x > 0))
                        {
                            var cartItemAddon = await query.GetEntitiesAsync<CartItemAddon>(x => x.CartItemId == ci.Id);
                            bool idsMatch = cartItemAddon.All(x => input.CartItemAddonIDs.Contains(x.AddonId))
                                && input.CartItemAddonIDs.All(id => cartItemAddon.Any(x => x.AddonId == id));

                            if (idsMatch)
                            {
                                var result1 = await UpdateQuantity(ci.Id, input.Quantity + ci.Quantity);
                                await transaction.CommitAsync();
                                return result1;
                            }
                        }
                        else
                        {
                            var result2 = await UpdateQuantity(ci.Id, input.Quantity + ci.Quantity);
                            await transaction.CommitAsync();
                            return result2;
                        }
                    }
                }
                var result = await command.AddAsync(cartItem);
                var cartItemAddons = new List<CartItemAddon>();
                if (input.CartItemAddonIDs != null && input.CartItemAddonIDs.All(x => x > 0))
                {

                    foreach (var AddonId in input.CartItemAddonIDs)
                        cartItemAddons.Add(new CartItemAddon
                        {
                            CartItemId = cartItem.Id,
                            AddonId = AddonId,
                            AddonPrice = await repos.GetAddonPrice(AddonId)
                        });

                    await command.AddRangAsync(cartItemAddons);
                }
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
                if (await repos.isCartOrdered(cartItemId))
                    throw new Exception("The cart has already been checked out and cannot be changed.");

                var cartItem = await query.GetEntityAsync<CartItem>(x => x.Id == cartItemId);
                var cartId = cartItem.CartId;
                var cartItemAddons = await query.GetEntitiesAsync<CartItemAddon>(x => x.CartItemId == cartItem.Id);
                await command.RemoveRangPermanentlyAsync(cartItemAddons);
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

        public async Task<int> UpdateQuantity(int cartItemId, int qty)
        {
            try
            {
                if (await repos.isCartOrdered(cartItemId))
                    throw new Exception("The cart has already been checked out and cannot be changed.");

                var cartItem = await query.GetEntityAsync<CartItem>(x => x.Id == cartItemId);
                if (cartItem == null) throw new Exception("CartItem Not Found");
                if (qty <= 0) return await RemoveFromCart(cartItemId);
                cartItem.Quantity = qty;
                var result = await command.UpdateAsync(cartItem);
                await UpdateCart(cartItem.CartId);
                return result;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<List<VoucherUserDTO>> GetUserVoucher(string userId)
            => await repos.GetUserVoucher(userId);

        public async Task<int> ApplyVoucher(string userId, int voucherId)
        {
            var transaction = await command.BeginTransactionAsync();
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

                if (userVoucher.UsagesLeft <= 0)
                    throw new Exception("Voucher usage limit exceeded for this user.");

                var cart = await query.GetEntityAsync<Cart>(c => c.UserId == userId && c.CartStatus == CartStatus.Active);
                if (cart == null) throw new Exception("Can't Apply Voucher , the cart is ordered");

                if (cart.Subtotal < voucher.MinimumOrderAmount)
                    throw new Exception($"The cart does not meet the minimum order amount '{voucher.MinimumOrderAmount}' required for this voucher.");

                cart.VoucherId = voucher.Id;
                cart.VoucherDiscount = voucher.IsPercentage ? (voucher.DiscountAmount * cart.Subtotal) / 100 : voucher.DiscountAmount;
                var result = await command.UpdateAsync(cart);
                await UpdateCart(cart.Id);
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> RemoveVoucher(string userId)
        {
            var transaction = await command.BeginTransactionAsync();
            try
            {
                var cart = await query.GetEntityAsync<Cart>(c => c.UserId == userId && c.CartStatus == CartStatus.Active);
                if (cart == null) throw new Exception("Can't Remove Voucher , the cart is ordered");
                cart.VoucherId = null;
                cart.VoucherDiscount = 0;
                var result = await command.UpdateAsync(cart);
                await UpdateCart(cart.Id);
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Order Service

        public async Task<IEnumerable<OrdersByDateDTO>> GetOrders(string userId)
         => await repos.GetOrders(userId);

        public async Task<OrderDetailsDTO> GetOrderDetails(int id)
            => await repos.GetOrderDetails(id);

        public async Task<int> Checkout(CheckoutDTO input, string userId)
        {
            var transaction = await command.BeginTransactionAsync();
            try
            {
                var order = new Order();

                var cart = await query.GetEntityAsync<Cart>(x => x.UserId == userId && x.CartStatus == CartStatus.Active && x.Subtotal > 0);
                if (cart == null)
                    throw new Exception("Empty Cart");

                order.CartId = cart.Id;
                order.UserAddressId = input.UserAddressId;
                bool isParsed = Enum.TryParse<PaymentMethod>(input.PaymentMethod, out var paymentMethod);
                if (!isParsed)
                    throw new Exception("Payment Method not Supported");
                order.PaymentMethod = paymentMethod;
                order.CustomerNotes = input.CustomerNotes;
                order.CreatedBy = userId;
                order.PaymentStatus = PaymentStatus.Pending;
                order.Status = OrderStatus.New;
                var userVoucher = await query.GetEntityWithNullAsync<VoucherUser>(x => x.UserId == userId && x.VoucherId == cart.VoucherId);
                if (userVoucher != null)
                    userVoucher.UsagesLeft -= 1;
                cart.CartStatus = CartStatus.Ordered;
                await command.AddAsync(order);
                await command.UpdateAsync(cart);
                if (userVoucher != null)
                    await command.UpdateAsync(userVoucher);
                await transaction.CommitAsync();
                return order.Id;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }

        #endregion

    }
}
