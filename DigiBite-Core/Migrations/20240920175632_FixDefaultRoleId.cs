using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DigiBite_Core.Migrations
{
    /// <inheritdoc />
    public partial class FixDefaultRoleId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00a109bf-6ace-4ea1-978e-ebac1ee5fa49");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1515df75-f9c3-4ee3-baba-78bbc11ab6bb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "167c8fdb-641f-40ec-97d9-6f71dbbe8ad7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c09aa58-6c11-4acd-b812-62a564564fda");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30401989-0582-4d05-8af1-e72382d1eb10");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d3b038e-ff32-4817-b5c9-278900d6e13f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64b018cd-be43-4fb8-9816-e248ce6a9a6b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7d3d3ed-cb67-4c57-bd7c-2fad07ac5cb8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1963b562-2920-43c6-9f4b-cbad0eae4640", null, "Delivery", "DELIVERY" },
                    { "2d65545d-5117-4c02-b38c-d16af39a735d", null, "Owner", "OWNER" },
                    { "33e72989-336c-4b02-b7ce-e592de9046ab", null, "Customer", "CUSTOMER" },
                    { "645e06ba-26e2-44f3-83cf-24e6314afbb1", null, "Waiter", "WAITER" },
                    { "a94d48ef-8114-4354-8f16-33e917d6cd6f", null, "Manager", "MANAGER" },
                    { "c87db997-3fc6-4353-8c15-8ae4b5fd84c7", null, "Chef", "CHEF" },
                    { "cc855f5f-1496-40b3-bee8-30e87739d57f", null, "Cashier", "CASHIER" },
                    { "d4ab4131-28dc-4ec5-a025-75191006777d", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1963b562-2920-43c6-9f4b-cbad0eae4640");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d65545d-5117-4c02-b38c-d16af39a735d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33e72989-336c-4b02-b7ce-e592de9046ab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "645e06ba-26e2-44f3-83cf-24e6314afbb1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a94d48ef-8114-4354-8f16-33e917d6cd6f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c87db997-3fc6-4353-8c15-8ae4b5fd84c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc855f5f-1496-40b3-bee8-30e87739d57f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4ab4131-28dc-4ec5-a025-75191006777d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00a109bf-6ace-4ea1-978e-ebac1ee5fa49", null, "Customer", "CUSTOMER" },
                    { "1515df75-f9c3-4ee3-baba-78bbc11ab6bb", null, "Admin", "ADMIN" },
                    { "167c8fdb-641f-40ec-97d9-6f71dbbe8ad7", null, "Delivery", "DELIVERY" },
                    { "1c09aa58-6c11-4acd-b812-62a564564fda", null, "Owner", "OWNER" },
                    { "30401989-0582-4d05-8af1-e72382d1eb10", null, "Cashier", "CASHIER" },
                    { "4d3b038e-ff32-4817-b5c9-278900d6e13f", null, "Waiter", "WAITER" },
                    { "64b018cd-be43-4fb8-9816-e248ce6a9a6b", null, "Chef", "CHEF" },
                    { "f7d3d3ed-cb67-4c57-bd7c-2fad07ac5cb8", null, "Manager", "MANAGER" }
                });
        }
    }
}
