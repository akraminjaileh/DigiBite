using System.ComponentModel.DataAnnotations;

namespace DigiBite_Core.DTOs.Account
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "UserName Is Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        public string Password { get; set; }
    }
}
