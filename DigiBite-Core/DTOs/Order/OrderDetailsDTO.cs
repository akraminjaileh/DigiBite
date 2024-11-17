using DigiBite_Core.Constant;
using DigiBite_Core.DTOs.Cart;

namespace DigiBite_Core.DTOs.Order
{
    public class OrderDetailsDTO
    {
        public int Id { get; set; }
        public DateTime CreationDateTime { get; set; }
        public string Status { get; set; } //Cancelled,Delivered
        public string CustomerNotes { get; set; }
        public decimal? Rating { get; set; }
        public string PaymentMethod { get; set; } //CreditCard,Cash,Wallet
        public string? AddressName { get; set; }
        public int CartId { get; set; }
        public CartDTO Cart { get; set; }

    }
}
