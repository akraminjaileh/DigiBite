namespace DigiBite_Core.Models.ManyToMany
{
    public class ItemIngredient
    {
        public int ItemId { get; set; }
        public int IngredientId { get; set; }
        public int QTY { get; set; }
    }
}
