using DigiBite_Core.Entities.Lookups;
using DigiBite_Core.Entities.ManyToMany;
using DigiBite_Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiBite_Core.EntityTypeConfigurations.ManyToManyConfiguration
{
    public class AddOnItemMealConfiguration : IEntityTypeConfiguration<AddOnItemMeal>
    {
        public void Configure(EntityTypeBuilder<AddOnItemMeal> builder)
        {
            //Key
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            //Foreign key 
            builder.HasOne<Item>().WithMany().HasForeignKey(x => x.ItemId);
            builder.HasOne<Meal>().WithMany().HasForeignKey(x => x.MealId);
            builder.HasOne<AddOnContainer>().WithMany().HasForeignKey(x => x.AddOnContainerId).OnDelete(DeleteBehavior.NoAction);

            //Nullable(is Not Null By Default) and Default value Config
            builder.Property(x => x.ItemId).IsRequired(false);
            builder.Property(x => x.MealId).IsRequired(false);


        }
    }

}
