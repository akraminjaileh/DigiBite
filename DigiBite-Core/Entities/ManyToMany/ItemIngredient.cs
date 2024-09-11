using static DigiBite_Core.Enums.DigiBiteEnums;

namespace DigiBite_Core.Models.ManyToMany
{
    public class ItemIngredient
    {
        public int ItemId { get; set; }
        public int IngredientId { get; set; }
        public int QTY { get; set; }
        public IngredientType IngredientType { get; set; }
        public decimal Price { get; set; }
    }
}
