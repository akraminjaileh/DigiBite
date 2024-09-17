using DigiBite_Core.Entities.Lookups;
using DigiBite_Core.Entities.ManyToMany;
using DigiBite_Core.EntityTypeConfigurations.EntityConfiguration;
using DigiBite_Core.EntityTypeConfigurations.IdentityConfiguration;
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
            // Identity Configuration
            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new IdentityRoleConfiguration());
 

            //BasicEntity Configuration 
            builder.ApplyConfiguration(new CartConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new IngredientConfiguration());
            builder.ApplyConfiguration(new ItemConfiguration());
            builder.ApplyConfiguration(new MealConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());

            //Lookup Configuration
            builder.ApplyConfiguration(new AddressConfiguration());
            builder.ApplyConfiguration(new ImageConfiguration());
            builder.ApplyConfiguration(new VoucherConfiguration());
            builder.ApplyConfiguration(new EmployeeInformationConfiguration());
            builder.ApplyConfiguration(new EmployeeDocumentConfiguration());

            //Many-Many Configuration
            builder.ApplyConfiguration(new CartItemConfiguration());
            builder.ApplyConfiguration(new ItemIngredientConfiguration());
            builder.ApplyConfiguration(new ItemMealConfiguration());
            builder.ApplyConfiguration(new VoucherUserConfiguration());

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
        public DbSet<Image> Images { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<ItemIngredient> ItemIngredients { get; set; }
        public DbSet<ItemMeal> ItemMeals { get; set; }
        public DbSet<VoucherUser> VoucherUsers { get; set; }
        public DbSet<EmployeeInformation> EmployeeInformation { get; set; }
        public DbSet<EmployeeDocument> EmployeeDocuments { get; set; }

    }
}
