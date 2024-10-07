using System.ComponentModel.DataAnnotations;

namespace DigiBite_Core.DTOs.Account
{
    public class ResetPasswordDTO
    {
        [Required]
        public string Token { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Max Length is 20 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
