using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigiBite_Core.Migrations
{
    /// <inheritdoc />
    public partial class OwnerRoleSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BanReason", "BanType", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "EmployeeInformationId", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImgId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c7ca5a1c-2e4b-4c8d-84fd-d9f011ad0a5b", 0, null, null, null, null, "admin@admin.com", true, null, "Akram", null, null, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEJBli493LHSGq6Y2GpOozFFMSPO5JcHdpViiU1Oq020cpHqoLaId9ZA6XOhr5AXbuQ==", "0787454867", true, null, null, false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2d65545d-5117-4c02-b38c-d16af39a735d", "c7ca5a1c-2e4b-4c8d-84fd-d9f011ad0a5b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2d65545d-5117-4c02-b38c-d16af39a735d", "c7ca5a1c-2e4b-4c8d-84fd-d9f011ad0a5b" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7ca5a1c-2e4b-4c8d-84fd-d9f011ad0a5b");
        }
    }
}
