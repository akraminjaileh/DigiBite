namespace DigiBite_Core.DTOs.Order
{
    public class OrdersByDateDTO
    {
        public DateTime? Date { get; set; }
        public IEnumerable<OrdersDTO>? Orders { get; set; }
    }
}
