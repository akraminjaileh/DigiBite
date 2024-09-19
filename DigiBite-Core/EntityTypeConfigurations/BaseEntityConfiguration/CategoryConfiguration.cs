using DigiBite_Core.Entities.Lookups;
using DigiBite_Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiBite_Core.EntityTypeConfigurations.EntityConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            //Foreign key 
            builder.HasOne<Entities.Lookups.File>().WithOne().HasForeignKey<Category>(x => x.ImageId);


            //Nullable(is Not Null By Default) and Default value Config
            builder.Property(x => x.ImageId).IsRequired(false);
            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.DescriptionEn).IsRequired(false);


            //Check Constraint
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_Category_Name", "LEN(Name) > 2"));


            //String Max Length
            builder.Property(x => x.Name).HasMaxLength(32);

        }
    }
}
