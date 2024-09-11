using DigiBite_Core.Entities.SharedEntity;
using DigiBite_Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static DigiBite_Core.Enums.DigiBiteEnums;

namespace DigiBite_Core.EntityTypeConfigurations.EntityConfiguration
{
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {

            //Foreign key 
            builder.HasOne<Image>().WithOne().HasForeignKey<Ingredient>(x => x.ImageId);


            //Nullable(is Not Null By Default) and Default value Config
            builder.Property(x=>x.ImageId).IsRequired(false);
            builder.Property(x => x.Unit).HasDefaultValue(IngredientUnit.Pieces);


            //String Max Length
            builder.Property(x => x.Name).HasMaxLength(50);

        }
    }
}
