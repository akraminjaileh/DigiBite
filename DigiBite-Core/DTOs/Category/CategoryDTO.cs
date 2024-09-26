namespace DigiBite_Core.DTOs.Category
{
    public class CategoryDTO
    {
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string Description { get; set; }
        public string DescriptionEn { get; set; }
        public List<Models.Entities.Item> Items { get; set; }

        //Relationships
        public int? ImageId { get; set; }
    }
}
