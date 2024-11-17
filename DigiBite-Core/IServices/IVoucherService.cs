using DigiBite_Core.DTOs.Voucher;

namespace DigiBite_Core.IServices
{
    public interface IVoucherService
    {
        Task<int> AssignVoucherToUser(List<string> userIds, int voucherId);
        Task<int> CreateVoucher(CreateVoucherDTO input, string userId);
        Task<VoucherDTO> GetVoucher(int id);
        Task<IEnumerable<VouchersDTO>> GetVouchers(int skip, int take, Dictionary<string, string> orderBy, string sortBy = null, bool isDescending = false);
        Task<int> RemoveVoucher(int id, string userId);
        Task<int> UpdateVoucher(int id, UpdateVoucherDTO input, string userId);
    }
}
