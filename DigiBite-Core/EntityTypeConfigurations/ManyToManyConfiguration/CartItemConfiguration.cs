using DigiBite_Core.Entities.ManyToMany;
using DigiBite_Core.Models.Entities;
using DigiBite_Core.Models.ManyToMany;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiBite_Core.EntityTypeConfigurations.ManyToManyConfiguration
{
    public partial class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasNoKey();
            //Foreign key 
            builder.HasOne<Cart>().WithMany().HasForeignKey(x => x.CartId);
            builder.HasOne<Item>().WithMany().HasForeignKey(x => x.ItemId);
            builder.HasOne<Meal>().WithMany().HasForeignKey(x => x.MealId);
            builder.HasOne<Ingredient>().WithMany().HasForeignKey(x => x.IngredientId);

            //Nullable(is Not Null By Default) and Default value Config
            builder.Property(x => x.ItemId).IsRequired(false);
            builder.Property(x => x.MealId).IsRequired(false);
            builder.Property(x => x.IngredientId).IsRequired(false);

            //Check Constraint
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_CartItem_QTY", "QTY > 0"));

        }


    }
}
