namespace DigiBite_Core.Entities.SharedEntity
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string AltText { get; set; }
        public bool IsPrimary { get; set; }

        //Relationships
        public int? ItemId { get; set; }
        public int? MealId { get; set; }


    }
}
