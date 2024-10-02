using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DigiBite_Core.DTOs.Media
{
    public class CreateMediaDTO
    {
        [StringLength(255, ErrorMessage = "File name cannot exceed 255 characters.")]
        public string FileName { get; set; }

        [StringLength(255, ErrorMessage = "Alt text cannot exceed 255 characters.")]
        public string AltText { get; set; }

        public bool? IsPrimary { get; set; }

        [Required(ErrorMessage = "The File is required.")]
        public IFormFile File { get; set; }

        // Relationships
        public int? ItemId { get; set; }  // Optional relationship to Item
        public int? MealId { get; set; }  // Optional relationship to Meal
    }

}
