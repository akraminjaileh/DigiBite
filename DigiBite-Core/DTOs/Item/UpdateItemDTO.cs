using System.ComponentModel.DataAnnotations;

namespace DigiBite_Core.DTOs.Item
{
    public class UpdateItemDTO
    {
        [Required(ErrorMessage = "Item Arabic Name is required.")]
        public string Name { get; set; }
        public string? NameEn { get; set; }
        [Required(ErrorMessage = "Item Arabic Description is required.")]
        public string Description { get; set; }
        public string? DescriptionEn { get; set; }
        public decimal Price { get; set; }
        public bool? IsAvailable { get; set; }
        public string CreatedBy { get; set; }
        public bool? IsInMenu { get; set; }

        //Relationships
        public int? CategoryId { get; set; }
    }
}
