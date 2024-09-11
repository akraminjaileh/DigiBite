namespace DigiBite_Core.Models.ManyToMany
{
    public class VoucherUser
    {
        public int VoucherId { get; set; }
        public string UserId { get; set; }
        public int UsagesLeft { get; set; }

    }
}
