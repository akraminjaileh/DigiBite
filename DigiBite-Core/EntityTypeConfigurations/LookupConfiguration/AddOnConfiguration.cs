using DigiBite_Core.Entities.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiBite_Core.EntityTypeConfigurations.LookupConfiguration
{
    public class AddOnConfiguration : IEntityTypeConfiguration<AddOn>
    {
        public void Configure(EntityTypeBuilder<AddOn> builder)
        {
            //Primary Key
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            //Foreign key 
            builder.HasOne<AddOnContainer>().WithMany().HasForeignKey(x => x.AddOnContainerId);

            //Nullable(is Not Null By Default) and Default value Config
            builder.Property(x => x.Price).HasDefaultValue(0);

            //String Max Length
            builder.Property(x => x.NameEn).HasMaxLength(256);
            builder.Property(x => x.Name).HasMaxLength(256);

        }
    }
}
