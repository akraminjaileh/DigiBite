﻿using DigiBite_Core.Entities.Lookups;
using DigiBite_Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiBite_Core.EntityTypeConfigurations.LookupConfiguration
{
    public class MediaConfiguration : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            //Primary Key
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            //Foreign key 
            builder.HasMany<Ingredient>().WithOne().HasForeignKey(x => x.ImageId);
            builder.HasMany<AddOn>().WithOne().HasForeignKey(x => x.ImageId);
            builder.HasMany<Category>().WithOne().HasForeignKey(x => x.ImageId);
            builder.HasOne<AppUser>().WithOne().HasForeignKey<AppUser>(x => x.ProfileImgId);

            //Nullable(is Not Null By Default) and Default value Config
            builder.Property(x => x.AltText).HasDefaultValue("FoodPhoto");
            builder.Property(x => x.UploadedOn).HasDefaultValueSql("SYSDATETIME()");

            //UNIQUE
            builder.HasIndex(x => x.ImageUrl).IsUnique(true);

            //String Max Length
            builder.Property(x => x.AltText).HasMaxLength(20);

        }
    }
}
