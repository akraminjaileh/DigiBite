using System.ComponentModel.DataAnnotations;

namespace DigiBite_Core.DTOs.Account
{
    public class InputEmailDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
