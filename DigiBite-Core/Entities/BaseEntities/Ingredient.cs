using DigiBite_Core.Models.SharedEntity;
using static DigiBite_Core.Enums.DigiBiteEnums;

namespace DigiBite_Core.Models.Entities
{
    public class Ingredient : Parent
    {
        public string Name { get; set; }
        public string NameEn { get; set; }
        public IngredientUnit Unit { get; set; }
        public int? ImageId { get; set; }

    }
}
