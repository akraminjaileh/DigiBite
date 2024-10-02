using DigiBite_Core.Models.SharedEntity;

namespace DigiBite_Core.Entities.Lookups
{
    public class AddOn : Parent
    {
        public string Name { get; set; }
        public string NameEn { get; set; }
        public decimal Price { get; set; }
        public int? ImageId { get; set; }
        public int AddOnContainerId { get; set; }
    }
}
