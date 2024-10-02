using DigiBite_Core.Entities.ManyToMany;
using DigiBite_Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiBite_Core.EntityTypeConfigurations.ManyToManyConfiguration
{
    public class MediaItemConfiguration : IEntityTypeConfiguration<MediaItem>
    {
        public void Configure(EntityTypeBuilder<MediaItem> builder)
        {
            //Primary Key
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            //Foreign key 
            builder.HasOne<Item>().WithMany().HasForeignKey(x => x.ItemId);
            builder.HasOne<Meal>().WithMany().HasForeignKey(x => x.MealId);

            //Nullable(is Not Null By Default) and Default value Config
            builder.Property(x => x.ItemId).IsRequired(false);
            builder.Property(x => x.MealId).IsRequired(false);
            builder.Property(x => x.IsPrimary).HasDefaultValue(false);

        }
    }
}
