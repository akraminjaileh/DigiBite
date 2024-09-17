using DigiBite_Core.Models.SharedEntity;

namespace DigiBite_Core.Entities.Lookups
{
    public class EmployeeDocument : Parent
    {
        public string DocumentName { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentPath { get; set; }
        public string DocumentNote { get; set; }

        // Relationship
        public int EmployeeInformationId { get; set; }
    }
}
