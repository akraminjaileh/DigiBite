using DigiBite_Core.Models.SharedEntity;

namespace DigiBite_Core.Entities.Lookups
{
    public class EmployeeInformation:Parent
    {
        public decimal? Salary { get; set; }
        public string BankName { get; set; }
        public string IBAN { get; set; }
        public string EmergencyPhone { get; set; }
        public string JobTitle { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string Nationality { get; set; }

    }
}
