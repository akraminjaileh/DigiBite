namespace DigiBite_Core.DTOs.Ingredient
{
    public class IngredientsWithImageDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IngredientUnit { get; set; }
        public int QTY { get; set; }
        public string? ImageUrl { get; set; }
    }
}
