using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static DigiBite_Core.Enums.DigiBiteEnums;

namespace DigiBite_Core.EntityTypeConfigurations.IdentityConfiguration
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.ToTable("Roles", "Security");

            builder.HasData(
                new IdentityRole
                {
                    Name = Enum.GetName(DefaultRole.Admin),
                    NormalizedName = Enum.GetName(DefaultRole.Admin).ToUpper()
                },
                new IdentityRole
                {
                    Name = Enum.GetName(DefaultRole.Manager),
                    NormalizedName = Enum.GetName(DefaultRole.Manager).ToUpper()
                },
                new IdentityRole
                {
                    Name = Enum.GetName(DefaultRole.Waiter),
                    NormalizedName = Enum.GetName(DefaultRole.Waiter).ToUpper()
                },
                new IdentityRole
                {
                    Name = Enum.GetName(DefaultRole.Chef),
                    NormalizedName = Enum.GetName(DefaultRole.Chef).ToUpper()
                },
                new IdentityRole
                {
                    Name = Enum.GetName(DefaultRole.Cashier),
                    NormalizedName = Enum.GetName(DefaultRole.Cashier).ToUpper()
                },
                new IdentityRole
                {
                    Name = Enum.GetName(DefaultRole.Delivery),
                    NormalizedName = Enum.GetName(DefaultRole.Delivery).ToUpper()
                },
                new IdentityRole
                {
                    Name = Enum.GetName(DefaultRole.Customer),
                    NormalizedName = Enum.GetName(DefaultRole.Customer).ToUpper()
                }

            );
        }
    }
}
