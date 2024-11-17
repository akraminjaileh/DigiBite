using DigiBite_Core.Context;
using DigiBite_Core.DTOs.Voucher;
using DigiBite_Core.Extension;
using DigiBite_Core.IRepos;
using Microsoft.EntityFrameworkCore;

namespace DigiBite_Infra.Repos
{
    public class VoucherRepos(DigiBiteContext context) : IVoucherRepos
    {

        public async Task<IEnumerable<VouchersDTO>> GetVouchers(int skip, int take,
            Dictionary<string, string> orderBy,
            string sortBy = null, bool isDescending = false)
        {
            try
            {
                var query = from v in context.Vouchers
                            .Where(i => i.IsActive == true)
                            .ApplyFilterAndSort(orderBy, sortBy, isDescending)
                            .Skip(skip)
                            .Take(take > 0 ? take : 20)

                            select new VouchersDTO
                            {
                                Id = v.Id,
                                Code = v.Code,
                                ScheduleStartDate = v.ScheduleStartDate,
                                ExpirationDate = v.ExpirationDate
                            };
                return await query.ToListAsync();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<VoucherDTO> GetVoucher(int id)
        {
            try
            {
                var query = from v in context.Vouchers
                            where v.Id == id && v.IsActive == true
                            select new VoucherDTO
                            {
                                Id = v.Id,
                                Code = v.Code,
                                ScheduleStartDate = v.ScheduleStartDate,
                                ExpirationDate = v.ExpirationDate,
                                MaxUsagesPerUser = v.MaxUsagesPerUser,
                                MinimumOrderAmount = v.MinimumOrderAmount,
                                DiscountAmount = v.DiscountAmount,
                                IsPercentage = v.IsPercentage,
                                CreatedBy = v.CreatedBy,
                                CreationDateTime = v.CreationDateTime,
                                LastModifiedBy = v.LastModifiedBy,
                                LastModifiedDateTime = v.LastModifiedDateTime
                            };
                var result = await query.FirstOrDefaultAsync();
                return result != null ? result : throw new Exception("No Voucher found");
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

       
    }
}
