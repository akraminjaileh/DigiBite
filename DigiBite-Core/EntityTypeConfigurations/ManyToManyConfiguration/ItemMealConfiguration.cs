using DigiBite_Core.Models.Entities;
using DigiBite_Core.Models.ManyToMany;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiBite_Core.EntityTypeConfigurations.ManyToManyConfiguration
{

    public class ItemMealConfiguration : IEntityTypeConfiguration<ItemMeal>
    {
        public void Configure(EntityTypeBuilder<ItemMeal> builder)
        {
            //Composite Key
            builder.HasKey(x => new { x.ItemId, x.MealId });

            //Foreign key 
            builder.HasOne<Item>().WithMany().HasForeignKey(x => x.ItemId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Meal>().WithMany().HasForeignKey(x => x.MealId).OnDelete(DeleteBehavior.NoAction);

            //Check Constraint
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_ItemMeal_QTY", "QTY > 0"));

        }
    }

}
