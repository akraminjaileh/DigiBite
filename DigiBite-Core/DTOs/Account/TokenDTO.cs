namespace DigiBite_Core.DTOs.Account
{
    public class TokenDTO
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public string CustomerName { get; set; }
    }
}
