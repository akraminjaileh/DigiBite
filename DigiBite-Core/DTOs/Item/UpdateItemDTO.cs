using DigiBite_Core.DTOs.AddOnItemMeal;
using DigiBite_Core.DTOs.ItemIngredient;
using System.ComponentModel.DataAnnotations;

namespace DigiBite_Core.DTOs.Item
{
    public class UpdateItemDTO
    {
        public string? Name { get; set; }
        public string? NameEn { get; set; }
        public string? Description { get; set; }
        public string? DescriptionEn { get; set; }
        public decimal? Price { get; set; }
        public bool? IsAvailable { get; set; }
        public bool? IsInMenu { get; set; }
        public int? CategoryId { get; set; }
        public List<ItemIngredientDTO> ItemIngredients { get; set; }
        public List<AddOnItemMealDTO> AddOnItemMeals { get; set; }
    }
}
