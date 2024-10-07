using DigiBite_Core.DTOs.AddOnItemMeal;
using DigiBite_Core.DTOs.ItemIngredient;

namespace DigiBite_Core.DTOs.Item
{
    public class AddItemDTO
    {
        public string Name { get; set; }
        public string? NameEn { get; set; }
        public string Description { get; set; }
        public string? DescriptionEn { get; set; }
        public decimal Price { get; set; }
        public bool? IsAvailable { get; set; }
        public bool? IsInMenu { get; set; }
        public int? CategoryId { get; set; }
        public IEnumerable<ItemIngredientDTO> ItemIngredients { get; set; }
        public IEnumerable<AddOnItemMealDTO> AddOnItemMeals { get; set; }

    }
}
