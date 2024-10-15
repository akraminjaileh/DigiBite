using DigiBite_Core.Entities.Lookups;
using DigiBite_Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DigiBite_Core.Constant;

namespace DigiBite_Core.EntityTypeConfigurations.EntityConfiguration
{
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {

            //Foreign key 
            builder.HasOne<Entities.Lookups.Media>().WithOne().HasForeignKey<Ingredient>(x => x.ImageId);

            //Nullable(is Not Null By Default) and Default value Config
            builder.Property(x=>x.ImageId).IsRequired(false);

            //String Max Length
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.NameEn).HasMaxLength(50);

        }
    }
}
