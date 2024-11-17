namespace DigiBite_Core.DTOs.Voucher
{
    public class UpdateVoucherDTO
    {

        public DateTime? ExpirationDate { get; set; }
        public decimal? MinimumOrderAmount { get; set; }
    }
}
