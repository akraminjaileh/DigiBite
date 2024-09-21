using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DigiBite_Core.Migrations
{
    /// <inheritdoc />
    public partial class FixDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ae67aa1-a99c-42df-92d3-3b551b9bdd84");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e1f96e2-3028-492c-bc6c-54d4c0136700");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2eb505e5-1752-42ff-a463-a6837605dea7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d492796-e47f-48ad-a435-c1e14993044c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9694064d-2269-46d0-b80b-c3a15edcb0a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcab0391-12fb-439b-8fcf-02d6c53d8809");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcd29aa5-f93b-460a-99d7-d3c6120288f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9d392e0-f1a1-42d3-a563-7f23714be90a");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ScheduleStartDate",
                table: "Vouchers",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "SYSDATETIME()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 20, 18, 59, 38, 505, DateTimeKind.Local).AddTicks(7407));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Vouchers",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "SYSDATETIME()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 526, DateTimeKind.Local).AddTicks(7302));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "SYSDATETIME()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 529, DateTimeKind.Local).AddTicks(3948));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Meals",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "SYSDATETIME()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 528, DateTimeKind.Local).AddTicks(7802));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "SYSDATETIME()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 528, DateTimeKind.Local).AddTicks(2307));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Ingredients",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "SYSDATETIME()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 527, DateTimeKind.Local).AddTicks(8697));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "EmployeeInformation",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "SYSDATETIME()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 526, DateTimeKind.Local).AddTicks(3538));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "EmployeeDocuments",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "SYSDATETIME()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 525, DateTimeKind.Local).AddTicks(9519));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "SYSDATETIME()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 527, DateTimeKind.Local).AddTicks(3552));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDateTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "SYSDATETIME()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 495, DateTimeKind.Local).AddTicks(355));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "SYSDATETIME()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 494, DateTimeKind.Local).AddTicks(9606));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "ScheduleStartDate",
                table: "Vouchers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 20, 18, 59, 38, 505, DateTimeKind.Local).AddTicks(7407),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "SYSDATETIME()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Vouchers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 526, DateTimeKind.Local).AddTicks(7302),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "SYSDATETIME()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 529, DateTimeKind.Local).AddTicks(3948),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "SYSDATETIME()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Meals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 528, DateTimeKind.Local).AddTicks(7802),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "SYSDATETIME()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 528, DateTimeKind.Local).AddTicks(2307),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "SYSDATETIME()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Ingredients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 527, DateTimeKind.Local).AddTicks(8697),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "SYSDATETIME()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "EmployeeInformation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 526, DateTimeKind.Local).AddTicks(3538),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "SYSDATETIME()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "EmployeeDocuments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 525, DateTimeKind.Local).AddTicks(9519),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "SYSDATETIME()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 527, DateTimeKind.Local).AddTicks(3552),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "SYSDATETIME()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDateTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 495, DateTimeKind.Local).AddTicks(355),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "SYSDATETIME()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 494, DateTimeKind.Local).AddTicks(9606),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "SYSDATETIME()");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ae67aa1-a99c-42df-92d3-3b551b9bdd84", null, "Cashier", "CASHIER" },
                    { "1e1f96e2-3028-492c-bc6c-54d4c0136700", null, "Chef", "CHEF" },
                    { "2eb505e5-1752-42ff-a463-a6837605dea7", null, "Customer", "CUSTOMER" },
                    { "3d492796-e47f-48ad-a435-c1e14993044c", null, "Manager", "MANAGER" },
                    { "9694064d-2269-46d0-b80b-c3a15edcb0a3", null, "Waiter", "WAITER" },
                    { "dcab0391-12fb-439b-8fcf-02d6c53d8809", null, "Owner", "OWNER" },
                    { "dcd29aa5-f93b-460a-99d7-d3c6120288f3", null, "Delivery", "DELIVERY" },
                    { "e9d392e0-f1a1-42d3-a563-7f23714be90a", null, "Admin", "ADMIN" }
                });
        }
    }
}
