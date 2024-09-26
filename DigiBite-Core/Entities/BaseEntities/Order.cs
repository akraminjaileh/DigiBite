using DigiBite_Core.Constant;
using DigiBite_Core.Models.SharedEntity;

namespace DigiBite_Core.Models.Entities
{
    public class Order : Parent
    {
        public OrderStatus Status { get; set; } //New,Confirmed,Cancelled,Delivered
        public DateTime? DeliveryDate { get; set; }
        public string CustomerNotes { get; set; }
        public decimal? Rating { get; set; }
        public PaymentStatus PaymentStatus { get; set; } //Pending, Paid,Failed
        public PaymentMethod PaymentMethod { get; set; } //CreditCard,Cash,Wallet

        //Relationships
        public int UserAddressId { get; set; }
        public int CartId { get; set; }



    }
}
