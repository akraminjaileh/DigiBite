using DigiBite_Core.Constant;

namespace DigiBite_Core.Models.ManyToMany
{
    public class ItemIngredient
    {
        public int ItemId { get; set; }
        public int IngredientId { get; set; }
        public IngredientUnit Unit { get; set; }
        public int QTY { get; set; }
    }
}
