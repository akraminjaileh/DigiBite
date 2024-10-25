namespace DigiBite_Core.DTOs.Address
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public string BuildingName { get; set; }
        public string ApartmentNumber { get; set; }
        public string Floor { get; set; }
        public string Street { get; set; }
        public string AdditionalDirection { get; set; }
        public string AddressLabel { get; set; }
        public bool IsPrimary { get; set; }
        public decimal Latitude { get; set; } // Latitude coordinate
        public decimal Longitude { get; set; } // Longitude coordinate

    }
}
