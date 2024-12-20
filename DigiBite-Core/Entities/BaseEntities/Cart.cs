﻿using DigiBite_Core.Constant;

namespace DigiBite_Core.Models.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public CartStatus CartStatus { get; set; } //"Active", "Ordered"
        public decimal? Subtotal { get; set; }
        public decimal? Discount { get; set; }
        public decimal? VoucherDiscount { get; set; }
        public decimal? DeliveryFee { get; set; }
        public decimal? ServiceFee { get; set; }
        public decimal? TotalAmount { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; }


        //Relationships
        public int? VoucherId { get; set; }

    }
}
