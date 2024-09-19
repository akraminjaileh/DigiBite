namespace DigiBite_Core.Entities.Lookups
{
    public class AddOn
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public decimal Price { get; set; }
        public int AddOnContainerId { get; set; }
    }
}
