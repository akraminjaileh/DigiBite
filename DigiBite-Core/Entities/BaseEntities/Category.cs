using DigiBite_Core.Models.SharedEntity;

namespace DigiBite_Core.Models.Entities
{
    public class Category : Parent
    {
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string Description { get; set; }
        public string DescriptionEn { get; set; }

        //Relationships
        public int? ImageId { get; set; }
    }
}
