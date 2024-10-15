namespace DigiBite_Core.Entities.ManyToMany
{
    public class CartItem
    {
        public int Id { get; set; }
        //Relationships
        public int CartId { get; set; }
        public int? ItemId { get; set; } 
        public int? MealId { get; set; } 
        public int Quantity { get; set; }
        public string? SpecialNotes { get; set; }
        public decimal ItemPrice { get; set; }  //Price at the time the item was added


    }
}
