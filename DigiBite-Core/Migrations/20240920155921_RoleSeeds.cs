using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DigiBite_Core.Migrations
{
    /// <inheritdoc />
    public partial class RoleSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03e8c969-0023-4e59-ac77-7d1f782a6485");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29412b25-5043-44cf-b439-d3299a0d11d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3962c760-7bd1-404e-9b12-0ca4798fc4a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c1d17cf-a7da-4a87-af61-c80a51aa02a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a89be0d5-2017-447c-9082-8fab3872e833");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc7dfdc2-0747-4d12-8b63-d14ab14e514e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f249e736-c7c7-429c-9bf0-19a930937d23");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ScheduleStartDate",
                table: "Vouchers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 20, 18, 59, 38, 505, DateTimeKind.Local).AddTicks(7407),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 19, 17, 59, 9, 747, DateTimeKind.Local).AddTicks(2999));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Vouchers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 526, DateTimeKind.Local).AddTicks(7302),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 773, DateTimeKind.Local).AddTicks(8106));

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 160,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 301);

            migrationBuilder.AlterColumn<int>(
                name: "PaymentStatus",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 180,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 501);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 529, DateTimeKind.Local).AddTicks(3948),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 777, DateTimeKind.Local).AddTicks(7837));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Meals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 528, DateTimeKind.Local).AddTicks(7802),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 777, DateTimeKind.Local).AddTicks(1020));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 528, DateTimeKind.Local).AddTicks(2307),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 776, DateTimeKind.Local).AddTicks(2343));

            migrationBuilder.AlterColumn<int>(
                name: "Unit",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 152,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 703);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Ingredients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 527, DateTimeKind.Local).AddTicks(8697),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 775, DateTimeKind.Local).AddTicks(5020));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "EmployeeInformation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 526, DateTimeKind.Local).AddTicks(3538),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 772, DateTimeKind.Local).AddTicks(9689));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "EmployeeDocuments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 525, DateTimeKind.Local).AddTicks(9519),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 772, DateTimeKind.Local).AddTicks(485));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 527, DateTimeKind.Local).AddTicks(3552),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 774, DateTimeKind.Local).AddTicks(8130));

            migrationBuilder.AlterColumn<int>(
                name: "CartStatus",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 120,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 401);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDateTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 495, DateTimeKind.Local).AddTicks(355),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 732, DateTimeKind.Local).AddTicks(4522));

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 142,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 203);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 494, DateTimeKind.Local).AddTicks(9606),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 732, DateTimeKind.Local).AddTicks(3863));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2024, 9, 19, 17, 59, 9, 747, DateTimeKind.Local).AddTicks(2999),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 20, 18, 59, 38, 505, DateTimeKind.Local).AddTicks(7407));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Vouchers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 773, DateTimeKind.Local).AddTicks(8106),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 526, DateTimeKind.Local).AddTicks(7302));

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 301,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 160);

            migrationBuilder.AlterColumn<int>(
                name: "PaymentStatus",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 501,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 180);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 777, DateTimeKind.Local).AddTicks(7837),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 529, DateTimeKind.Local).AddTicks(3948));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Meals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 777, DateTimeKind.Local).AddTicks(1020),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 528, DateTimeKind.Local).AddTicks(7802));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 776, DateTimeKind.Local).AddTicks(2343),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 528, DateTimeKind.Local).AddTicks(2307));

            migrationBuilder.AlterColumn<int>(
                name: "Unit",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 703,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 152);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Ingredients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 775, DateTimeKind.Local).AddTicks(5020),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 527, DateTimeKind.Local).AddTicks(8697));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "EmployeeInformation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 772, DateTimeKind.Local).AddTicks(9689),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 526, DateTimeKind.Local).AddTicks(3538));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "EmployeeDocuments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 772, DateTimeKind.Local).AddTicks(485),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 525, DateTimeKind.Local).AddTicks(9519));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 774, DateTimeKind.Local).AddTicks(8130),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 527, DateTimeKind.Local).AddTicks(3552));

            migrationBuilder.AlterColumn<int>(
                name: "CartStatus",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 401,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 120);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDateTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 732, DateTimeKind.Local).AddTicks(4522),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 495, DateTimeKind.Local).AddTicks(355));

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 203,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 142);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 732, DateTimeKind.Local).AddTicks(3863),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 20, 18, 59, 18, 494, DateTimeKind.Local).AddTicks(9606));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03e8c969-0023-4e59-ac77-7d1f782a6485", null, "Cashier", "CASHIER" },
                    { "29412b25-5043-44cf-b439-d3299a0d11d0", null, "Customer", "CUSTOMER" },
                    { "3962c760-7bd1-404e-9b12-0ca4798fc4a2", null, "Delivery", "DELIVERY" },
                    { "6c1d17cf-a7da-4a87-af61-c80a51aa02a2", null, "Admin", "ADMIN" },
                    { "a89be0d5-2017-447c-9082-8fab3872e833", null, "Waiter", "WAITER" },
                    { "dc7dfdc2-0747-4d12-8b63-d14ab14e514e", null, "Chef", "CHEF" },
                    { "f249e736-c7c7-429c-9bf0-19a930937d23", null, "Manager", "MANAGER" }
                });
        }
    }
}
