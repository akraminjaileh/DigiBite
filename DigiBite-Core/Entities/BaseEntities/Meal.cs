using DigiBite_Core.Models.SharedEntity;

namespace DigiBite_Core.Models.Entities
{
    public class Meal : Parent
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }

        //Relationships
        public int CategoryId { get; set; }
    }
}
