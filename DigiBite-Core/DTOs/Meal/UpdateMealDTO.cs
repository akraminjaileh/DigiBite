using DigiBite_Core.DTOs.AddOnItemMeal;
using DigiBite_Core.DTOs.MealItem;

namespace DigiBite_Core.DTOs.Meal
{
    public class UpdateMealDTO
    {
        public string? Name { get; set; }
        public string? NameEn { get; set; }
        public string? Description { get; set; }
        public string? DescriptionEn { get; set; }
        public decimal? Price { get; set; }
        public bool? IsAvailable { get; set; }
        public bool? IsInMenu { get; set; }
        public int? CategoryId { get; set; }
        public List<MealItemDTO> MealItems { get; set; }
        public List<AddOnItemMealDTO> AddOnItemMeals { get; set; }
    }
}
