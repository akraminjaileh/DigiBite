using DigiBite_Core.Entities.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiBite_Core.EntityTypeConfigurations.LookupConfiguration
{
    public class EmployeeDocumentConfiguration : IEntityTypeConfiguration<EmployeeDocument>
    {
        public void Configure(EntityTypeBuilder<EmployeeDocument> builder)
        {

            //Foreign key 
            builder.HasOne<EmployeeInformation>().WithMany().HasForeignKey(x => x.EmployeeInformationId);

            //Nullable(is Not Null By Default) and Default value Config
            builder.Property(x => x.DocumentPath).IsRequired(false);
            builder.Property(x => x.DocumentNote).IsRequired(false);
            builder.Property(x => x.DocumentNumber).IsRequired(false);

            //UNIQUE
            builder.HasIndex(x => x.DocumentNumber).IsUnique(true);
            // Making the DocumentNumber column unique but allowing null
            builder.HasIndex(x => x.DocumentNumber).IsUnique()
                              .HasFilter("[DocumentNumber] IS NOT NULL");

        }
    }
}
