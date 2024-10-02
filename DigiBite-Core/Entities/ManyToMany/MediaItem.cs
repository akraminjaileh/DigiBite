namespace DigiBite_Core.Entities.ManyToMany
{
    public class MediaItem
    {
        public int Id { get; set; }
        //Relationships
        public int MediaId { get; set; }
        public int? ItemId { get; set; }
        public int? MealId { get; set; }
        public bool IsPrimary { get; set; }
    }
}
