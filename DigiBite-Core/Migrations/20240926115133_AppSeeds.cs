using DigiBite_Core.Constant;
using DigiBite_Core.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigiBite_Core.Migrations
{
    /// <inheritdoc />
    public partial class AppSeeds : Migration
    {
        private readonly string _superAdminId = "2b060fce-aba3-4660-9bd7-2ab32b8df4fb";
        private readonly string _roleSuperAdminId = "01b4d39c-953a-4155-a660-cff3a42b9437";
        private readonly string _roleAdminId = "d4ab4131-28dc-4ec5-a025-75191006777d";
        private readonly string _roleManagerId = "a94d48ef-8114-4354-8f16-33e917d6cd6f";
        private readonly string _roleCustomerId = "33e72989-336c-4b02-b7ce-e592de9046ab";
        private readonly string _roleCashierId = "cc855f5f-1496-40b3-bee8-30e87739d57f";
        private readonly string _roleDeliveryId = "1963b562-2920-43c6-9f4b-cbad0eae4640";
        private readonly string _roleWaiterId = "645e06ba-26e2-44f3-83cf-24e6314afbb1";
        private readonly string _roleChefId = "c87db997-3fc6-4353-8c15-8ae4b5fd84c7";
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Add Default Role
            migrationBuilder.InsertData(
              table: "AspNetRoles",
              columns: new[] { "Id", "Name", "NormalizedName" },
              values: new object[,]
              {
                 { _roleSuperAdminId, Role.SuperAdmin.ToString(), Role.SuperAdmin.ToString().ToUpper() },
                 { _roleAdminId, Role.Admin.ToString(), Role.Admin.ToString().ToUpper() },
                 { _roleManagerId, Role.Manager.ToString(), Role.Manager.ToString().ToUpper() },
                 { _roleWaiterId, Role.Waiter.ToString(), Role.Waiter.ToString().ToUpper() },
                 { _roleChefId, Role.Chef.ToString(), Role.Chef.ToString().ToUpper() },
                 { _roleCashierId, Role.Cashier.ToString(), Role.Cashier.ToString().ToUpper()},
                 { _roleDeliveryId, Role.Delivery.ToString(), Role.Delivery.ToString().ToUpper() },
                 { _roleCustomerId, Role.Customer.ToString(), Role.Customer.ToString().ToUpper() }
              }
            );

            // Add SuperAdmin Account
            var passwordHasher = new PasswordHasher<AppUser>();
            var superAdmin = new AppUser
            {
                Id = _superAdminId,
                FirstName = "Akram",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                PhoneNumber = "0787454867",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "Admin@1234")
            };

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[]
                {
                 "Id", "FirstName", "Email", "NormalizedEmail", "UserName", "NormalizedUserName",
                 "EmailConfirmed", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled",
                 "LockoutEnabled", "AccessFailedCount", "ConcurrencyStamp", "SecurityStamp", "PasswordHash"
                },
                values: new object[]
                {
                 superAdmin.Id, superAdmin.FirstName, superAdmin.Email, superAdmin.NormalizedEmail, superAdmin.UserName,
                 superAdmin.NormalizedUserName, superAdmin.EmailConfirmed, superAdmin.PhoneNumber,
                 superAdmin.PhoneNumberConfirmed, superAdmin.TwoFactorEnabled, superAdmin.LockoutEnabled,
                 superAdmin.AccessFailedCount, superAdmin.ConcurrencyStamp, superAdmin.SecurityStamp, superAdmin.PasswordHash
                }
            );
            // Assign SuperAdmin to SuperAdmin Role
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { superAdmin.Id, _roleSuperAdminId }
            );

          
            // Assign SuperAdmin to RoleClaim
            foreach (var roleClaim in RoleClaim.Claims)
            {
                migrationBuilder.InsertData(
                     table: "AspNetRoleClaims",
                    columns: new[] { "RoleId", "ClaimType", "ClaimValue" },
                    values: new object[] { _roleSuperAdminId, roleClaim.Key, "true" }
                );
            }
            // Add Default Category
            migrationBuilder.InsertData(
                    table: "Categories",
                    columns: new[] { "Id", "Name", "NameEn", "CreatedBy" },
                    values: new object[] { 1, "غير مصنف", "Uncategorized", _superAdminId }
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
             table: "AspNetRoles",
             keyColumn: "Id",
             keyValues: new object[] { _roleSuperAdminId, _roleAdminId, _roleManagerId, _roleCustomerId, _roleCashierId, _roleDeliveryId, _roleWaiterId, _roleChefId }
            );

            migrationBuilder.DeleteData(
               table: "AspNetUserRoles",
               keyColumns: new[] { "UserId", "RoleId" },
               keyValues: new object[] { _superAdminId, _roleSuperAdminId }
            );

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: _superAdminId
            );

          

            foreach (var roleClaim in RoleClaim.Claims)
            {
                migrationBuilder.DeleteData(
                    table: "AspNetRoleClaims",
                    keyColumns: new[] { "RoleId", "ClaimType" },
                    keyValues: new object[] { _roleSuperAdminId, roleClaim.Key }
                );
            }
            migrationBuilder.DeleteData(
                     table: "Categories",
                     keyColumn: "Id",
                     keyValue: 1
            );
        }
    }
}
