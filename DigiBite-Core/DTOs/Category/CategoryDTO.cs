using DigiBite_Core.DTOs.Media;

namespace DigiBite_Core.DTOs.Category
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ImageAltTextDTO? ImageUrl { get; set; }
    }
}
