using DigiBite_Core.Constant;

namespace DigiBite_Core.DTOs.Ingredient
{
    public class AddIngredientDTO
    {
        public string Name { get; set; }
        public string NameEn { get; set; }
        public IngredientUnit Unit { get; set; }
        public int? ImageId { get; set; }
    }
}
