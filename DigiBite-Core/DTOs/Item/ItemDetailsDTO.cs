using DigiBite_Core.Entities.Lookups;
using DigiBite_Core.Models.ManyToMany;

namespace DigiBite_Core.DTOs.Item
{
    public class ItemDetailsDTO
    {
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string Description { get; set; }
        public string DescriptionEn { get; set; }
        public decimal Price { get; set; }
        public bool? IsAvailable { get; set; }
        public bool? IsInMenu { get; set; }
        public Media Image { get; set; }
        public ItemIngredient Ingredient { get; set; }
        public AddOnContainer AddOnContainer { get; set; }

        //Relationships
        public int CategoryId { get; set; }

        public int Id { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreationDateTime { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
    }
}
