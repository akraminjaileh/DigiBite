using DigiBite_Core.Constant;

namespace DigiBite_Core.DTOs.Account
{
    public class UpdateProfileDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public Gender? Gender { get; set; }
        public string? DateOfBirth { get; set; }
    }
}
