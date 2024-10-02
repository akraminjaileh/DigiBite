using DigiBite_Core.DTOs.AddOnItemMeal;
using DigiBite_Core.DTOs.ItemIngredient;
using DigiBite_Core.Entities.ManyToMany;
using System.ComponentModel.DataAnnotations;

namespace DigiBite_Core.DTOs.Item
{
    public class AddItemDTO
    {
        [Required(ErrorMessage = "Item Arabic Name is required.")]
        public string Name { get; set; }
        public string? NameEn { get; set; }
        [Required(ErrorMessage = "Item Arabic Description is required.")]
        public string Description { get; set; }
        public string? DescriptionEn { get; set; }
        public decimal Price { get; set; }
        public bool? IsAvailable { get; set; }
        public bool? IsInMenu { get; set; }
        public int? CategoryId { get; set; }
        public IEnumerable<ItemIngredientDTO> ItemIngredients { get; set; }
        public IEnumerable<AddOnItemMealDTO> AddOnItemMeals { get; set; }
        public IEnumerable<int> MediaIDs { get; set; }

    }
}
