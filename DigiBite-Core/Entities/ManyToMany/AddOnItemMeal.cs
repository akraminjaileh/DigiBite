﻿namespace DigiBite_Core.Entities.ManyToMany
{
    public class AddOnItemMeal
    {
        public int Id { get; set; }
        public int AddOnContainerId { get; set; }
        public int? ItemId { get; set; }
        public int? MealId { get; set; }
    }
}
