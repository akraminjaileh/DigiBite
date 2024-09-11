using DigiBite_Core.Models.Entities;
using DigiBite_Core.Models.ManyToMany;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static DigiBite_Core.Enums.DigiBiteEnums;

namespace DigiBite_Core.EntityTypeConfigurations.ManyToManyConfiguration
{

    public class ItemIngredientConfiguration : IEntityTypeConfiguration<ItemIngredient>
    {
        public void Configure(EntityTypeBuilder<ItemIngredient> builder)
        {
            //Composite Key
            builder.HasKey(x => new { x.IngredientId, x.ItemId });

            //Foreign key 
            builder.HasOne<Item>().WithMany().HasForeignKey(x => x.ItemId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Ingredient>().WithMany().HasForeignKey(x => x.IngredientId).OnDelete(DeleteBehavior.NoAction);

            //Nullable(is Not Null By Default) and Default value Config
            builder.Property(x => x.IngredientType).HasDefaultValue(IngredientType.Free);
            builder.Property(x => x.Price).HasDefaultValue(0);


            //Check Constraint
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_ItemIngredient_QTY", "QTY > 0"));

        }
    }

}
