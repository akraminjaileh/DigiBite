using DigiBite_Core.Constant;
using DigiBite_Core.Context;
using DigiBite_Core.DTOs.Address;
using DigiBite_Core.DTOs.Cart;
using DigiBite_Core.DTOs.CartItem;
using DigiBite_Core.DTOs.CartItemAddon;
using DigiBite_Core.DTOs.Voucher;
using DigiBite_Core.IRepos;
using Microsoft.EntityFrameworkCore;

namespace DigiBite_Infra.Repos
{
    public class CustomerActionRepos(DigiBiteContext context) : ICustomerActionRepos
    {

        public async Task<IEnumerable<AddressesDTO>> GetAddresses(string userId)
        {
            try
            {
                var query = from a in context.Addresses
                            where a.UserId == userId && a.IsActive == true
                            select new AddressesDTO
                            {
                                Id = a.Id,
                                ApartmentNumber = a.ApartmentNumber,
                                BuildingName = a.BuildingName,
                                IsPrimary = a.IsPrimary
                            };
                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<AddressDTO> GetAddressById(int id, string userId)
        {
            try
            {
                var query = from a in context.Addresses
                            where a.Id == id && a.UserId == userId && a.IsActive == true
                            select new AddressDTO
                            {
                                Id = a.Id,
                                AddressLabel = a.AddressLabel,
                                ApartmentNumber = a.ApartmentNumber,
                                BuildingName = a.BuildingName,
                                Street = a.Street,
                                AdditionalDirection = a.AdditionalDirection,
                                Floor = a.Floor,
                                IsPrimary = a.IsPrimary,
                                Latitude = a.Latitude,
                                Longitude = a.Longitude

                            };
                var result = await query.FirstOrDefaultAsync();
                return result != null ? result : throw new Exception("Address not found");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        #region Cart Action
        public async Task<ItemPriceDTO> GetPrice(int id, bool isMeal)
        {
            try
            {
                var query = isMeal ?

                    from i in context.Meals
                    where i.Id == id
                    select new ItemPriceDTO { Id = i.Id, Price = i.Price }

                : from i in context.Items
                  where i.Id == id
                  select new ItemPriceDTO { Id = i.Id, Price = i.Price };

                var result = await query.FirstOrDefaultAsync();
                return result is not null ? result : throw new Exception($"item or meal with id : {id} not found");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> GetCartId(string userId)
        => await (from c in context.Carts
                  where c.UserId == userId && c.CartStatus == CartStatus.Active
                  select c.Id).FirstOrDefaultAsync();

        public async Task<CartDTO> GetActiveCart(string userId)
        {
            try
            {
                var query = from c in context.Carts
                            where c.UserId == userId && c.CartStatus == CartStatus.Active
                            select new CartDTO

                            {
                                Id = c.Id,
                                CartStatus = c.CartStatus,
                                DeliveryFee = c.DeliveryFee,
                                Discount = c.Discount,
                                ServiceFee = c.ServiceFee,
                                Subtotal = c.Subtotal,
                                VoucherDiscount = c.VoucherDiscount,
                                TotalAmount = c.TotalAmount,
                                VoucherId = c.VoucherId,
                                CartItems = (from ci in context.CartItems
                                             where c.Id == ci.CartId
                                             select new CartItemDTO
                                             {
                                                 Id = ci.Id,
                                                 CartId = ci.CartId,
                                                 ItemId = ci.ItemId,
                                                 ItemPrice = ci.ItemPrice,
                                                 MealId = ci.MealId,
                                                 Quantity = ci.Quantity,
                                                 SpecialNotes = ci.SpecialNotes,
                                                 CartItemAddons = (from ca in context.CartItemAddons
                                                                   where ci.Id == ca.CartItemId
                                                                   select new CartItemAddonDTO
                                                                   {
                                                                       CartItemId = ca.CartItemId,
                                                                       AddonId = ca.AddonId,
                                                                       AddonPrice = ca.AddonPrice
                                                                   }).ToList()
                                             }).ToList()
                            };

                return await query.FirstOrDefaultAsync();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<decimal> CalculateSubtotal(int cartId)
        {
            try
            {
                return await (from ci in context.CartItems
                              where ci.CartId == cartId
                              join ca in context.CartItemAddons
                              on ci.Id equals ca.CartItemId
                              select (ci.Quantity * ci.ItemPrice) + ca.AddonPrice).SumAsync();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<List<VoucherUserDTO>> GetUserVoucher(string userId)
        {
            var query = from uv in context.VoucherUsers
                        where uv.UserId == userId
                        join v in context.Vouchers
                             on uv.VoucherId equals v.Id
                        where v.MaxUsagesPerUser > uv.UsagesLeft
                              && v.ExpirationDate <= DateTime.Now
                              && v.IsActive == true
                        select new VoucherUserDTO
                        {
                            Id = v.Id,
                            Code = v.Code,
                            DiscountAmount = v.DiscountAmount,
                            ExpirationDate = v.ExpirationDate,
                            IsPercentage = v.IsPercentage,
                            MaxUsagesPerUser = v.MaxUsagesPerUser,
                            MinimumOrderAmount = v.MinimumOrderAmount,
                            ScheduleStartDate = v.ScheduleStartDate,
                            UsagesLeft = uv.UsagesLeft
                        };
            return await query.ToListAsync();
        }

        #endregion

    }
}
