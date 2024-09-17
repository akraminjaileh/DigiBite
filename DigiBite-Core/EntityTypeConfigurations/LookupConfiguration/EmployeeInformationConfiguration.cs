using DigiBite_Core.Entities.Lookups;
using DigiBite_Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiBite_Core.EntityTypeConfigurations.LookupConfiguration
{
    public class EmployeeInformationConfiguration : IEntityTypeConfiguration<EmployeeInformation>
    {
        public void Configure(EntityTypeBuilder<EmployeeInformation> builder)
        {

            //Foreign key 
            builder.HasOne<AppUser>().WithOne().HasForeignKey<AppUser>(x => x.EmployeeInformationId);

            //Nullable(is Not Null By Default) and Default value Config
            builder.Property(x => x.Salary).IsRequired(false);
            builder.Property(x => x.BankName).IsRequired(false);
            builder.Property(x => x.IBAN).IsRequired(false);
            builder.Property(x => x.JobTitle).IsRequired(false);
            builder.Property(x => x.Nationality).IsRequired(false);

            //UNIQUE
            // Making the IBAN column unique but allowing null
            builder.HasIndex(x => x.IBAN).IsUnique()
                              .HasFilter("[IBAN] IS NOT NULL");


            //String Max Length
            builder.Property(x => x.IBAN).HasMaxLength(34);

        }
    }
}
