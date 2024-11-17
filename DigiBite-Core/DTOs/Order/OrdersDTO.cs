using DigiBite_Core.Constant;

namespace DigiBite_Core.DTOs.Order
{
    public class OrdersDTO
    {
        public int Id { get; set; }
        public string Status { get; set; } //Cancelled,Delivered
        public string ItemNames { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
