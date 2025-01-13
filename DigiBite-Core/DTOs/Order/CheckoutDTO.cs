using DigiBite_Core.Constant;

namespace DigiBite_Core.DTOs.Order
{
    public class CheckoutDTO
    {
        public string? CustomerNotes { get; set; }
        public string PaymentMethod { get; set; } //CreditCard,Cash,Wallet
        public int UserAddressId { get; set; }
    }
}
