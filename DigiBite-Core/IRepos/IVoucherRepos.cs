using DigiBite_Core.DTOs.Voucher;

namespace DigiBite_Core.IRepos
{
    public interface IVoucherRepos
    {
        Task<VoucherDTO> GetVoucher(int id);
        Task<IEnumerable<VouchersDTO>> GetVouchers(int skip, int take, Dictionary<string, string> orderBy, string sortBy = null, bool isDescending = false);
    }
}
