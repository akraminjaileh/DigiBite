using DigiBite_Core.DTOs.Ingredient;

namespace DigiBite_Core.DTOs.Item
{
    public class ItemsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? PrimaryImageUrl { get; set; }
        public IEnumerable<IngredientsWithDetailsDTO> Ingredients { get; set; }
        public bool? IsAvailable { get; set; }
        public bool? IsInMenu { get; set; }
    }
}
