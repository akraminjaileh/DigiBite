using DigiBite_Core.Constant;
using DigiBite_Core.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiBite_Core.DbSeeds
{
    public class OwnerSeed : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {

            var Owner = new AppUser
            {
                Id = SeedsConstant.OwnerId,
                FirstName ="Akram",
                Email = "admin@admin.com",
                NormalizedEmail = "admin@admin.com".ToUpper(),
                UserName = "admin",
                NormalizedUserName = "admin".ToUpper(),
                EmailConfirmed = true,
                PhoneNumber = "0787454867",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                ConcurrencyStamp = null,//"65eee213-baf1-402d-97e5-a94286898f9b",
                SecurityStamp = null//"b88e32f8-5ae9-4b64-b8fc-0fc74f4a3068"
            };
            Owner.PasswordHash = new PasswordHasher<AppUser>().HashPassword(Owner, "Admin@1234");

            builder.HasData(Owner);

        } 
    }

    public class RoleOwnerSeed : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {

            builder.HasData(new IdentityUserRole<string>
            {
                RoleId = SeedsConstant.RoleOwnerId,
                UserId = SeedsConstant.OwnerId

            });
        }
    }

}
