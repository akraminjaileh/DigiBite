namespace DigiBite_Core.DTOs.Voucher
{
    public class VouchersDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime ScheduleStartDate { get; set; }
    }
}
