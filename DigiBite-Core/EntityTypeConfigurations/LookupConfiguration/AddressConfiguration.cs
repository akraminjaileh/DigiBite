using DigiBite_Core.Models.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiBite_Core.EntityTypeConfigurations.LookupConfiguration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            //Primary Key
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            //Nullable(is Not Null By Default) and Default value Config
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.AdditionalDirection).IsRequired(false);
            builder.Property(x => x.AddressLabel).IsRequired(false);
            builder.Property(x => x.IsPrimary).HasDefaultValue(false);


            //String Max Length
            builder.Property(x => x.AddressLabel).HasMaxLength(50);
            builder.Property(x => x.ApartmentNumber).HasMaxLength(30);
            builder.Property(x => x.BuildingName).HasMaxLength(100);
            builder.Property(x => x.Street).HasMaxLength(500);
        }
    }
}
