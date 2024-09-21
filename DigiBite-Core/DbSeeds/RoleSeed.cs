using DigiBite_Core.Constant;
using DigiBite_Core.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiBite_Core.Seed
{
    public class RoleSeed : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {

            builder.HasData(

              new IdentityRole
              {
                  Id = SeedsConstant.RoleOwnerId,
                  Name = Enum.GetName(Role.Owner),
                  NormalizedName = Enum.GetName(Role.Owner).ToUpper()
              },
              new IdentityRole
              {
                  Id = SeedsConstant.RoleAdminId,
                  Name = Enum.GetName(Role.Admin),
                  NormalizedName = Enum.GetName(Role.Admin).ToUpper()
              },
              new IdentityRole
              {
                  Id = SeedsConstant.RoleManagerId,
                  Name = Enum.GetName(Role.Manager),
                  NormalizedName = Enum.GetName(Role.Manager).ToUpper()
              },
              new IdentityRole
              {
                  Id = SeedsConstant.RoleCustomerId,
                  Name = Enum.GetName(Role.Customer),
                  NormalizedName = Enum.GetName(Role.Customer).ToUpper()
              },
              new IdentityRole
              {
                  Id = SeedsConstant.RoleCashierId,
                  Name = Enum.GetName(Role.Cashier),
                  NormalizedName = Enum.GetName(Role.Cashier).ToUpper()
              },
              new IdentityRole
              {
                  Id = SeedsConstant.RoleDeliveryId,
                  Name = Enum.GetName(Role.Delivery),
                  NormalizedName = Enum.GetName(Role.Delivery).ToUpper()
              },
              new IdentityRole
              {
                  Id = SeedsConstant.RoleWaiterId,
                  Name = Enum.GetName(Role.Waiter),
                  NormalizedName = Enum.GetName(Role.Waiter).ToUpper()
              },
              new IdentityRole
              {
                  Id = SeedsConstant.RoleChefId,
                  Name = Enum.GetName(Role.Chef),
                  NormalizedName = Enum.GetName(Role.Chef).ToUpper()
              }

            );
        }
    }
}
