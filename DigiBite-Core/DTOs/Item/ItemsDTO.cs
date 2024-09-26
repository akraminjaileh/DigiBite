using DigiBite_Core.Entities.Lookups;
using DigiBite_Core.Models.ManyToMany;

namespace DigiBite_Core.DTOs.Item
{
    public class ItemsDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<Media> Image { get; set; }
        public List<ItemIngredient> Ingredient { get; set; }
        public bool? IsAvailable { get; set; }
        public bool? IsInMenu { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreationDateTime { get; set; }
        public object Category { get; set; }
    }
}
