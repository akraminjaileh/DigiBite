using DigiBite_Core.Constant;
using DigiBite_Core.Context;
using DigiBite_Core.DTOs.Address;
using DigiBite_Core.DTOs.Cart;
using DigiBite_Core.DTOs.CartItem;
using DigiBite_Core.DTOs.CartItemAddon;
using DigiBite_Core.DTOs.Item;
using DigiBite_Core.DTOs.Media;
using DigiBite_Core.DTOs.Order;
using DigiBite_Core.DTOs.Voucher;
using DigiBite_Core.Helpers;
using DigiBite_Core.IRepos;
using DigiBite_Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

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
        public async Task<decimal> GetAddonPrice(int id)
        {
            try
            {
                var query = from a in context.AddOns
                            where a.Id == id
                            select a.Price;

                if (query.IsNullOrEmpty())
                    throw new Exception($"Addon with id : {id} not found");

                return await query.FirstOrDefaultAsync();
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
        public async Task<bool> isCartOrdered(int cartItemId)
        {
            try
            {
                return await (from c in context.Carts
                              join ci in context.CartItems
                              on c.Id equals ci.CartId
                              where ci.Id == cartItemId && c.CartStatus == CartStatus.Ordered
                              select true).FirstOrDefaultAsync();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public async Task<CartDTO> GetCartDetails(Expression<Func<Cart, bool>> predicate)
        {
            try
            {
                var query = from c in context.Carts
                            .Where(predicate)
                            select new CartDTO

                            {
                                Id = c.Id,
                                CartStatus = c.CartStatus.ToString(),
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
                                                 ItemPrice = ci.ItemPrice,
                                                 Quantity = ci.Quantity,
                                                 SpecialNotes = ci.SpecialNotes,
                                                 ItemInCart = (from i in context.Items
                                                               where i.Id == ci.ItemId
                                                               select new ItemInCartDTO
                                                               {
                                                                   Name = LanguageService.SelectLang(i.Name, i.NameEn),
                                                                   PrimaryImageUrl = (from img in context.Medias
                                                                                      join imgItem in context.MediaItems
                                                                                      on img.Id equals imgItem.MediaId
                                                                                      where imgItem.ItemId == i.Id && imgItem.IsPrimary
                                                                                      select new ImageAltTextDTO
                                                                                      {
                                                                                          FileName = img.FileName,
                                                                                          AltText = img.AltText,
                                                                                          ImageUrl = img.ImageUrl
                                                                                      }).FirstOrDefault(),
                                                               }).FirstOrDefault()
                                                             ??
                                                            (from m in context.Meals
                                                             where m.Id == ci.MealId
                                                             select new ItemInCartDTO
                                                             {
                                                                 Name = LanguageService.SelectLang(m.Name, m.NameEn),
                                                                 PrimaryImageUrl = (from img in context.Medias
                                                                                    join imgItem in context.MediaItems
                                                                                    on img.Id equals imgItem.MediaId
                                                                                    where imgItem.ItemId == m.Id && imgItem.IsPrimary
                                                                                    select new ImageAltTextDTO
                                                                                    {
                                                                                        FileName = img.FileName,
                                                                                        AltText = img.AltText,
                                                                                        ImageUrl = img.ImageUrl
                                                                                    }).FirstOrDefault(),
                                                             }).FirstOrDefault(),

                                                 CartItemAddons = (from ca in context.CartItemAddons
                                                                   where ci.Id == ca.CartItemId
                                                                   select new CartItemAddonDTO
                                                                   {
                                                                       AddonPrice = ca.AddonPrice,
                                                                       AddonName = (from a in context.AddOns
                                                                                    where ca.AddonId == a.Id
                                                                                    select LanguageService.SelectLang(a.Name, a.NameEn)).First()
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

                var cartItemTotals = await (from ci in context.CartItems
                                            where ci.CartId == cartId
                                            let addonTotal = (from a in context.CartItemAddons
                                                              where ci.Id == a.CartItemId
                                                              select a.AddonPrice).Sum()
                                            select (ci.Quantity * ci.ItemPrice) + addonTotal).ToListAsync();

                var result = cartItemTotals.Sum();

                return result;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<List<VoucherUserDTO>> GetUserVoucher(string userId)
        {
            var query = from uv in context.VoucherUsers
                        where uv.UserId == userId
                        join v in context.Vouchers
                             on uv.VoucherId equals v.Id
                        where uv.UsagesLeft > 0
                              && v.ExpirationDate >= DateTime.Now
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


        #region Order

        public async Task<IEnumerable<OrdersByDateDTO>> GetOrders(string userId)
        {
            try
            {
                var query = from o in context.Orders
                            where o.CreatedBy == userId
                            group o by o.CreationDateTime.Date into orderGP
                            orderby orderGP.Key descending
                            select new OrdersByDateDTO
                            {
                                Date = orderGP.Key.Date,
                                Orders = orderGP.Select(o => new OrdersDTO
                                {
                                    Id = o.Id,
                                    Status = o.Status.ToString(),
                                    TotalAmount = (from c in context.Carts
                                                   where c.Id == o.CartId
                                                   select c.TotalAmount).SingleOrDefault() ?? 0,

                                    ItemNames = string.Join(", ",
                                    (from ci in context.CartItems
                                     where ci.CartId == o.CartId
                                     join i in context.Items on ci.ItemId equals i.Id
                                     select LanguageService.SelectLang(i.Name, i.NameEn) + $" * {ci.Quantity}").ToList())
                                })
                            };
                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<OrderDetailsDTO> GetOrderDetails(int id)
        {
            try
            {
                var query = from o in context.Orders
                            where o.Id == id
                            select new OrderDetailsDTO
                            {
                                Id = o.Id,
                                CreationDateTime = o.CreationDateTime,
                                CustomerNotes = o.CustomerNotes,
                                PaymentMethod = o.PaymentMethod.ToString(),
                                Status = o.Status.ToString(),
                                Rating = o.Rating,
                                AddressName = (from a in context.Addresses
                                               where a.Id == o.UserAddressId
                                               select string.Join(",", a.AddressLabel, a.BuildingName)).FirstOrDefault(),
                                CartId = o.CartId
                            };
                var order = await query.FirstOrDefaultAsync();
                if (order == null || order.CartId == 0)
                    throw new Exception("Order Not found");
                order.Cart = await GetCartDetails(x => x.Id == order.CartId);
                return order;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        #endregion

    }
}
