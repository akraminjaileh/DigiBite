using DigiBite_Core.DTOs.CartItem;

namespace DigiBite_Core.DTOs.Cart
{
    public class CartDTO
    {
        public int Id { get; set; }
        public string CartStatus { get; set; } //"Active", "Ordered"
        public decimal? Subtotal { get; set; }
        public decimal? Discount { get; set; }
        public decimal? VoucherDiscount { get; set; }
        public decimal? DeliveryFee { get; set; }
        public decimal? ServiceFee { get; set; }
        public decimal? TotalAmount { get; set; }
        public int? VoucherId { get; set; }
        public List<CartItemDTO> CartItems { get; set; }

    }
}
