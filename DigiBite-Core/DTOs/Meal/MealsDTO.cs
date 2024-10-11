using DigiBite_Core.DTOs.Item;

namespace DigiBite_Core.DTOs.Meal
{
    public class MealsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? PrimaryImageUrl { get; set; }
        public IEnumerable<ItemOnMealDTO> Items { get; set; }
        public bool? IsAvailable { get; set; }
        public bool? IsInMenu { get; set; }
    }
}
