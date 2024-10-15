namespace DigiBite_Core.Entities.ManyToMany
{
    public class CartItemAddon
    {
        public int CartItemId { get; set; }
        public int AddonId { get; set; }
        public decimal AddonPrice { get; set; }  //Price at the time the Addon was added
    }
}
