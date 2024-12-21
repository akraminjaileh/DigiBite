namespace DigiBite_Core.DTOs.Address
{
    public class CreateAddressDTO
    {
        public string BuildingName { get; set; }
        public string ApartmentNumber { get; set; }
        public string Floor { get; set; }
        public string Street { get; set; }
        public string? AdditionalDirection { get; set; }
        public string? AddressLabel { get; set; }
        public bool IsPrimary { get; set; }
        public double Latitude { get; set; } // Latitude coordinate
        public double Longitude { get; set; } // Longitude coordinate
    }
}
