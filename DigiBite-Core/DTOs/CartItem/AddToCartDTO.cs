using DigiBite_Core.DTOs.CartItemAddon;

namespace DigiBite_Core.DTOs.CartItem
{
    public class AddToCartDTO
    {
        public int? ItemId { get; set; }
        public int? MealId { get; set; }
        public int Quantity { get; set; }
        public string? SpecialNotes { get; set; }
        public List<int>? CartItemAddonIDs { get; set; }
    }
}
