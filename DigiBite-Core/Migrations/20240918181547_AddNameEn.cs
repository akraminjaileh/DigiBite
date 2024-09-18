using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DigiBite_Core.Migrations
{
    /// <inheritdoc />
    public partial class AddNameEn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27853cd6-c826-4654-acc0-baba99c70d9d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ccdc996-6dc9-4d82-8b7d-48b2adc0fb06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "411ba147-a4e5-4325-9e25-99d18f6d5c13");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48bdf511-1df9-408e-a714-1fab42c6359a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bf9ea32-2843-434b-b628-93233b84becd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f1f0964-49a7-445a-9d84-63d400f40e77");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bffc9512-0cbe-4cd4-ac14-520646162408");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ScheduleStartDate",
                table: "Vouchers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 18, 21, 16, 4, 763, DateTimeKind.Local).AddTicks(1781),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 17, 22, 4, 12, 135, DateTimeKind.Local).AddTicks(6559));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Vouchers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 780, DateTimeKind.Local).AddTicks(6012),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 17, 22, 3, 52, 162, DateTimeKind.Local).AddTicks(4040));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 784, DateTimeKind.Local).AddTicks(22),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 17, 22, 3, 52, 164, DateTimeKind.Local).AddTicks(8909));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Meals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 783, DateTimeKind.Local).AddTicks(1651),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 17, 22, 3, 52, 164, DateTimeKind.Local).AddTicks(5117));

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEn",
                table: "Meals",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "Meals",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 782, DateTimeKind.Local).AddTicks(6432),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 17, 22, 3, 52, 163, DateTimeKind.Local).AddTicks(9185));

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEn",
                table: "Items",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "Items",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Ingredients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 781, DateTimeKind.Local).AddTicks(8680),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 17, 22, 3, 52, 163, DateTimeKind.Local).AddTicks(5137));

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "Ingredients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Width",
                table: "Images",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Height",
                table: "Images",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "EmployeeInformation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 780, DateTimeKind.Local).AddTicks(2391),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 17, 22, 3, 52, 161, DateTimeKind.Local).AddTicks(9521));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "EmployeeDocuments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 779, DateTimeKind.Local).AddTicks(7795),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 17, 22, 3, 52, 161, DateTimeKind.Local).AddTicks(3742));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 780, DateTimeKind.Local).AddTicks(9673),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 17, 22, 3, 52, 162, DateTimeKind.Local).AddTicks(7819));

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEn",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDateTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 747, DateTimeKind.Local).AddTicks(3338),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 17, 22, 3, 52, 113, DateTimeKind.Local).AddTicks(9390));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 747, DateTimeKind.Local).AddTicks(2607),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 17, 22, 3, 52, 113, DateTimeKind.Local).AddTicks(8241));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "05e09c80-cc4f-4cd3-a06c-a568a696d52e", null, "Waiter", "WAITER" },
                    { "12d09ce5-35b6-465e-b7bd-9a1f93bd4921", null, "Admin", "ADMIN" },
                    { "3c34ed60-2025-43e9-8df4-1fd08d64486f", null, "Manager", "MANAGER" },
                    { "577dda2d-0969-4170-accc-3faaca25de75", null, "Customer", "CUSTOMER" },
                    { "58828f51-dece-4ef1-99b1-9859a73f25e6", null, "Chef", "CHEF" },
                    { "c8594f67-c4d0-4174-acbc-f1edb3d9bbbf", null, "Cashier", "CASHIER" },
                    { "e4fd75a6-dedd-4b45-aba0-b1f9c8294828", null, "Delivery", "DELIVERY" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05e09c80-cc4f-4cd3-a06c-a568a696d52e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12d09ce5-35b6-465e-b7bd-9a1f93bd4921");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c34ed60-2025-43e9-8df4-1fd08d64486f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "577dda2d-0969-4170-accc-3faaca25de75");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58828f51-dece-4ef1-99b1-9859a73f25e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8594f67-c4d0-4174-acbc-f1edb3d9bbbf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4fd75a6-dedd-4b45-aba0-b1f9c8294828");

            migrationBuilder.DropColumn(
                name: "DescriptionEn",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "DescriptionEn",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "DescriptionEn",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "Categories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ScheduleStartDate",
                table: "Vouchers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 17, 22, 4, 12, 135, DateTimeKind.Local).AddTicks(6559),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 18, 21, 16, 4, 763, DateTimeKind.Local).AddTicks(1781));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Vouchers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 17, 22, 3, 52, 162, DateTimeKind.Local).AddTicks(4040),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 780, DateTimeKind.Local).AddTicks(6012));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 17, 22, 3, 52, 164, DateTimeKind.Local).AddTicks(8909),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 784, DateTimeKind.Local).AddTicks(22));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Meals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 17, 22, 3, 52, 164, DateTimeKind.Local).AddTicks(5117),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 783, DateTimeKind.Local).AddTicks(1651));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 17, 22, 3, 52, 163, DateTimeKind.Local).AddTicks(9185),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 782, DateTimeKind.Local).AddTicks(6432));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Ingredients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 17, 22, 3, 52, 163, DateTimeKind.Local).AddTicks(5137),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 781, DateTimeKind.Local).AddTicks(8680));

            migrationBuilder.AlterColumn<int>(
                name: "Width",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Height",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "EmployeeInformation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 17, 22, 3, 52, 161, DateTimeKind.Local).AddTicks(9521),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 780, DateTimeKind.Local).AddTicks(2391));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "EmployeeDocuments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 17, 22, 3, 52, 161, DateTimeKind.Local).AddTicks(3742),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 779, DateTimeKind.Local).AddTicks(7795));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 17, 22, 3, 52, 162, DateTimeKind.Local).AddTicks(7819),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 780, DateTimeKind.Local).AddTicks(9673));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDateTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 17, 22, 3, 52, 113, DateTimeKind.Local).AddTicks(9390),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 747, DateTimeKind.Local).AddTicks(3338));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 17, 22, 3, 52, 113, DateTimeKind.Local).AddTicks(8241),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 747, DateTimeKind.Local).AddTicks(2607));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27853cd6-c826-4654-acc0-baba99c70d9d", null, "Customer", "CUSTOMER" },
                    { "2ccdc996-6dc9-4d82-8b7d-48b2adc0fb06", null, "Chef", "CHEF" },
                    { "411ba147-a4e5-4325-9e25-99d18f6d5c13", null, "Waiter", "WAITER" },
                    { "48bdf511-1df9-408e-a714-1fab42c6359a", null, "Cashier", "CASHIER" },
                    { "9bf9ea32-2843-434b-b628-93233b84becd", null, "Admin", "ADMIN" },
                    { "9f1f0964-49a7-445a-9d84-63d400f40e77", null, "Manager", "MANAGER" },
                    { "bffc9512-0cbe-4cd4-ac14-520646162408", null, "Delivery", "DELIVERY" }
                });
        }
    }
}
