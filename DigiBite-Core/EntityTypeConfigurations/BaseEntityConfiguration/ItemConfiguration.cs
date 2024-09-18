using DigiBite_Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiBite_Core.EntityTypeConfigurations.EntityConfiguration
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {

            //Nullable(is Not Null By Default) and Default value Config
            builder.Property(x => x.IsAvailable).HasDefaultValue(true);
            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.DescriptionEn).IsRequired(false);

            //String Max Length
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.NameEn).HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.DescriptionEn).HasMaxLength(500);

        }
    }
}
