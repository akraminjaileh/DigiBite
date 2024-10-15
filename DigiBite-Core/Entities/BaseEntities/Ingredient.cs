using DigiBite_Core.Models.SharedEntity;

namespace DigiBite_Core.Models.Entities
{
    public class Ingredient : Parent
    {
        public string Name { get; set; }
        public string NameEn { get; set; }
        public int? ImageId { get; set; }

    }
}
