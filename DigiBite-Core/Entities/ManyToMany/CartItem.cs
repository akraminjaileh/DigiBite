namespace DigiBite_Core.Entities.ManyToMany
{
    public class CartItem
    {
        //Relationships
        public int CartId { get; set; }
        public int? ItemId { get; set; } 
        public int? MealId { get; set; } 
        public int? IngredientId { get; set; } 
        public int QTY { get; set; }

    }
}
