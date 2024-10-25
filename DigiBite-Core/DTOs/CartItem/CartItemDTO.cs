﻿using DigiBite_Core.DTOs.CartItemAddon;

namespace DigiBite_Core.DTOs.CartItem
{
    public class CartItemDTO
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int? ItemId { get; set; }
        public int? MealId { get; set; }
        public int Quantity { get; set; }
        public string? SpecialNotes { get; set; }
        public decimal ItemPrice { get; set; }
        public List<CartItemAddonDTO> CartItemAddons { get; set; }

    }
}