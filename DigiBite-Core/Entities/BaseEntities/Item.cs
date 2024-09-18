using DigiBite_Core.Models.SharedEntity;

namespace DigiBite_Core.Models.Entities
{
    public class Item : Parent
    {
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string Description { get; set; }
        public string DescriptionEn { get; set; }
        public string Price { get; set; }
        public bool IsAvailable { get; set; }


        //Relationships
        public int CategoryId { get; set; }
    }
}
