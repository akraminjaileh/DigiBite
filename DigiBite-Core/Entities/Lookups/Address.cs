using DigiBite_Core.Models.SharedEntity;

namespace DigiBite_Core.Models.Lookups
{
    public class Address
    {
        public int Id { get; set; }
        public string BuildingName { get; set; }
        public string ApartmentNumber { get; set; }
        public string Floor { get; set; }
        public string Street { get; set; }
        public string AdditionalDirection { get; set; }
        public string AddressLabel { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsActive { get; set; }
       

        // Properties for Google Maps integration
        public decimal Latitude { get; set; } // Latitude coordinate
        public decimal Longitude { get; set; } // Longitude coordinate

        //Relationship
        public string UserId { get; set; }

    }

}
