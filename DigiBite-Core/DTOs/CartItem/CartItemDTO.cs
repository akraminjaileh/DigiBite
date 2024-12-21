using DigiBite_Core.DTOs.CartItemAddon;
using DigiBite_Core.DTOs.Item;

namespace DigiBite_Core.DTOs.CartItem
{
    public class CartItemDTO
    {
        public int Id { get; set; }
        public ItemInCartDTO? ItemInCart { get; set; }
        public int Quantity { get; set; }
        public string? SpecialNotes { get; set; }
        public decimal ItemPrice { get; set; }
        public List<CartItemAddonDTO> CartItemAddons { get; set; }

    }
}
