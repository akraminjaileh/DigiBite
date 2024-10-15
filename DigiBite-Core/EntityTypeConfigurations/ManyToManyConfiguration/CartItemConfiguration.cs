using DigiBite_Core.Entities.ManyToMany;
using DigiBite_Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiBite_Core.EntityTypeConfigurations.ManyToManyConfiguration
{
    public partial class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            //Key
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            //Foreign key 
            builder.HasOne<Cart>().WithMany().HasForeignKey(x => x.CartId);
            builder.HasOne<Item>().WithMany().HasForeignKey(x => x.ItemId);
            builder.HasOne<Meal>().WithMany().HasForeignKey(x => x.MealId);

            //Nullable(is Not Null By Default) and Default value Config
            builder.Property(x => x.ItemId).IsRequired(false);
            builder.Property(x => x.MealId).IsRequired(false);
            builder.Property(x => x.SpecialNotes).IsRequired(false);

            //Check Constraint
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_CartItem_Quantity", "Quantity > 0"));

            //String Max Length
            builder.Property(x => x.SpecialNotes).HasMaxLength(256);

        }


    }
}
