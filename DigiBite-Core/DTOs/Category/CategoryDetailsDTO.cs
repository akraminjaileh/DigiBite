namespace DigiBite_Core.DTOs.Category
{
    public class CategoryDetailsDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CreationDateTime { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }

    }
}
