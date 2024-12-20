﻿using DigiBite_Core.Entities.Lookups;
using DigiBite_Core.Entities.ManyToMany;
using DigiBite_Core.EntityTypeConfigurations.BaseEntityConfiguration;
using DigiBite_Core.EntityTypeConfigurations.EntityConfiguration;
using DigiBite_Core.EntityTypeConfigurations.LookupConfiguration;
using DigiBite_Core.EntityTypeConfigurations.ManyToManyConfiguration;
using DigiBite_Core.EntityTypeConfigurations.SharedConfiguration;
using DigiBite_Core.Models.Entities;
using DigiBite_Core.Models.Lookups;
using DigiBite_Core.Models.ManyToMany;
using DigiBite_Core.Models.SharedEntity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DigiBite_Core.Context
{
    public class DigiBiteContext : IdentityDbContext<AppUser>
    {
        public DigiBiteContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //BasicEntity Configuration 
            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new CartConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new IngredientConfiguration());
            builder.ApplyConfiguration(new ItemConfiguration());
            builder.ApplyConfiguration(new MealConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());

            //Lookup Configuration
            builder.ApplyConfiguration(new AddressConfiguration());
            builder.ApplyConfiguration(new MediaConfiguration());
            builder.ApplyConfiguration(new VoucherConfiguration());
            builder.ApplyConfiguration(new EmployeeInformationConfiguration());
            builder.ApplyConfiguration(new EmployeeDocumentConfiguration());
            builder.ApplyConfiguration(new AddOnConfiguration());
            builder.ApplyConfiguration(new AddOnContainerConfiguration());

            //Many-Many Configuration
            builder.ApplyConfiguration(new CartItemConfiguration());
            builder.ApplyConfiguration(new ItemIngredientConfiguration());
            builder.ApplyConfiguration(new ItemMealConfiguration());
            builder.ApplyConfiguration(new VoucherUserConfiguration());
            builder.ApplyConfiguration(new AddOnItemMealConfiguration());
            builder.ApplyConfiguration(new MediaItemConfiguration());
            builder.ApplyConfiguration(new CartItemAddonConfiguration());

            // Apply ParentConfiguration to all entities that inherit from Parent
            var parentType = typeof(Parent);
            var entityTypes = parentType
                .Assembly
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(parentType));

            foreach (var type in entityTypes)
            {
                var configurationType = typeof(ParentConfiguration<>).MakeGenericType(type);
                var configurationInstance = Activator.CreateInstance(configurationType);
                if (configurationInstance != null)
                    builder.ApplyConfiguration((dynamic)configurationInstance);
            }

        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<MediaItem> MediaItems { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<ItemIngredient> ItemIngredients { get; set; }
        public DbSet<ItemMeal> ItemMeals { get; set; }
        public DbSet<VoucherUser> VoucherUsers { get; set; }
        public DbSet<EmployeeInformation> EmployeeInformation { get; set; }
        public DbSet<EmployeeDocument> EmployeeDocuments { get; set; }
        public DbSet<AddOnContainer> AddOnContainers { get; set; }
        public DbSet<AddOn> AddOns { get; set; }
        public DbSet<AddOnItemMeal> AddOnItemMeals { get; set; }
        public DbSet<CartItemAddon>  CartItemAddons { get; set; }

    }
}
