using DigiBite_Core.DTOs.AddOnContainer;
using DigiBite_Core.DTOs.Item;

namespace DigiBite_Core.DTOs.Meal
{
    public class MealDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool? IsAvailable { get; set; }
        public bool? IsInMenu { get; set; }
        public IEnumerable<string> ImageUrls { get; set; }
        public IEnumerable<ItemOnMealWithImageDTO> Items { get; set; }
        public IEnumerable<AddOnContainerDTO> AddOnContainers { get; set; }

        public string? CategoryName { get; set; }

        public DateTime CreationDateTime { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
    }
}
