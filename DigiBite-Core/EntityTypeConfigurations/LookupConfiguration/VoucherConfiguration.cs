using DigiBite_Core.Models.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiBite_Core.EntityTypeConfigurations.LookupConfiguration
{
    public class VoucherConfiguration : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {

            //Nullable(is Not Null By Default) and Default value Config
            builder.Property(x => x.ScheduleStartDate).HasDefaultValueSql("SYSDATETIME()");
            builder.Property(x => x.ScheduleStartDate).HasDefaultValueSql("SYSDATETIME()");

            //Check Constraint
            
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_Voucher_ScheduleStartDate", "ScheduleStartDate >= SYSDATETIME()"));
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_Voucher_ExpirationDate", "ExpirationDate > ScheduleStartDate"));
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_Voucher_MaxUsagesPerUser", "MaxUsagesPerUser > 0"));


            //String Max Length
            builder.Property(x => x.Code).HasMaxLength(30);
        }
    }
}
