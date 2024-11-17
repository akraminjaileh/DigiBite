using DigiBite_Core.DTOs.Voucher;
using DigiBite_Core.IRepos;
using DigiBite_Core.IServices;
using DigiBite_Core.Models.Lookups;
using DigiBite_Core.Models.ManyToMany;

namespace DigiBite_Infra.Services
{
    public class VoucherService(IVoucherRepos repos, ICommandRepos command, IQueryRepos query) : IVoucherService
    {
        public async Task<IEnumerable<VouchersDTO>> GetVouchers(int skip, int take,
            Dictionary<string, string> orderBy,
            string sortBy = null, bool isDescending = false)
            => await repos.GetVouchers(skip, take, orderBy, sortBy, isDescending);

        public async Task<VoucherDTO> GetVoucher(int id)
            => await repos.GetVoucher(id);

        public async Task<int> CreateVoucher(CreateVoucherDTO input, string userId)
        {
            try
            {
                var voucher = new Voucher
                {
                    Code = input.Code,
                    DiscountAmount = input.DiscountAmount,
                    ExpirationDate = input.ExpirationDate,
                    IsPercentage = input.IsPercentage,
                    MaxUsagesPerUser = input.MaxUsagesPerUser,
                    MinimumOrderAmount = input.MinimumOrderAmount,
                    ScheduleStartDate = input.ScheduleStartDate,
                    CreationDateTime = DateTime.Now,
                    CreatedBy = userId
                };

                return await command.AddAsync(voucher);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<int> UpdateVoucher(int id, UpdateVoucherDTO input, string userId)
        {
            try
            {
                var voucher = await query.GetEntityAsync<Voucher>(x => x.Id == id);
                voucher.MinimumOrderAmount = input.MinimumOrderAmount ?? voucher.MinimumOrderAmount;
                voucher.ExpirationDate = input.ExpirationDate ?? voucher.ExpirationDate;
                voucher.LastModifiedBy = userId;
                voucher.LastModifiedDateTime = DateTime.Now;
                return await command.UpdateAsync(voucher);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<int> RemoveVoucher(int id, string userId)
        {
            try
            {
                var voucher = await query.GetEntityAsync<Voucher>(x => x.Id == id);
                voucher.IsActive = false;
                voucher.LastModifiedBy = userId;
                voucher.LastModifiedDateTime = DateTime.Now;
                return await command.UpdateAsync(voucher);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<int> AssignVoucherToUser(List<string> userIds, int voucherId)
        {
            try
            {
                var voucher = await query.GetEntityAsync<Voucher>(x => x.Id == voucherId);
                if (voucher == null) throw new Exception($"Voucher with Id: {voucherId} not Found");

                var voucherUsers = new List<VoucherUser>();
                foreach (string userId in userIds)
                {
                    voucherUsers.Add(new VoucherUser
                    {
                        UserId = userId,
                        VoucherId = voucherId,
                        UsagesLeft = voucher.MaxUsagesPerUser
                    });
                }
               return await command.AddRangAsync(voucherUsers);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
