using DigiBite_Core.Entities.Lookups;
using DigiBite_Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiBite_Core.EntityTypeConfigurations.LookupConfiguration
{
    public class FileConfiguration : IEntityTypeConfiguration<Entities.Lookups.File>
    {
        public void Configure(EntityTypeBuilder<Entities.Lookups.File> builder)
        {
            //Primary Key
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            //Foreign key 
            builder.HasOne<Item>().WithMany().HasForeignKey(x => x.ItemId);
            builder.HasOne<Meal>().WithMany().HasForeignKey(x => x.MealId);
            builder.HasOne<Ingredient>().WithOne().HasForeignKey<Ingredient>(x => x.ImageId);
            builder.HasOne<AppUser>().WithOne().HasForeignKey<AppUser>(x => x.ProfileImgId);
            builder.HasOne<Category>().WithOne().HasForeignKey<Category>(x => x.ImageId);



            //Nullable(is Not Null By Default) and Default value Config
            builder.Property(x => x.AltText).HasDefaultValue("FoodPhoto");
            builder.Property(x => x.IsPrimary).HasDefaultValue(false);
            builder.Property(x => x.Width).IsRequired(false);
            builder.Property(x => x.Height).IsRequired(false);
            builder.Property(x => x.ItemId).IsRequired(false);
            builder.Property(x => x.MealId).IsRequired(false);

            //UNIQUE
            builder.HasIndex(x => x.ImageUrl).IsUnique(true);

            //String Max Length
            builder.Property(x => x.AltText).HasMaxLength(20);

        }
    }
}
