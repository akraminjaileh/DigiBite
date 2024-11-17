namespace DigiBite_Core.DTOs.Voucher
{
    public class CreateVoucherDTO
    {
        public string Code { get; set; }
        public decimal DiscountAmount { get; set; }  // Fixed discount amount or percentage
        public bool IsPercentage { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime ScheduleStartDate { get; set; }
        public decimal MinimumOrderAmount { get; set; }
        public int MaxUsagesPerUser { get; set; }
              
    }
}
