using System.ComponentModel.DataAnnotations;

namespace DigiBite_Core.DTOs.Account
{
    public class SignupDTO
    {
        [Required(ErrorMessage = "First name is required.")]
        public required string FirstName { get; set; }

        public string? LastName { get; set; }
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }

        public string Password { get; set; }

    }

}
