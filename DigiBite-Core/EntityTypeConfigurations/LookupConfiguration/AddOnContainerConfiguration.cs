using DigiBite_Core.Entities.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiBite_Core.EntityTypeConfigurations.LookupConfiguration
{
    public class AddOnContainerConfiguration : IEntityTypeConfiguration<AddOnContainer>
    {
        public void Configure(EntityTypeBuilder<AddOnContainer> builder)
        {

            //String Max Length
            builder.Property(x => x.Name).HasMaxLength(256);
            builder.Property(x => x.NameEn).HasMaxLength(256);

        }
    }
}
