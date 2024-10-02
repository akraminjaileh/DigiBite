using DigiBite_Core.DTOs.AddOnContainer;
using DigiBite_Core.DTOs.Category;
using DigiBite_Core.DTOs.Ingredient;

namespace DigiBite_Core.DTOs.Item
{
    public class ItemDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool? IsAvailable { get; set; }
        public bool? IsInMenu { get; set; }
        public IEnumerable<string> ImageUrls { get; set; }
        public IEnumerable<IngredientsWithImageDTO> Ingredients { get; set; }
        public IEnumerable<AddOnContainerDTO> AddOnContainers { get; set; }

        public string? CategoryName { get; set; }

        public DateTime CreationDateTime { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
    }
}
