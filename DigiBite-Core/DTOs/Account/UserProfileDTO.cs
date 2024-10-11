using DigiBite_Core.Constant;

namespace DigiBite_Core.DTOs.Account
{
    public class UserProfileDTO
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public Gender? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? ProfileImgUrl { get; set; }

    }
}
