using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DigiBite_Core.Migrations
{
    /// <inheritdoc />
    public partial class AddOnCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "IngredientType",
                table: "ItemIngredients");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ItemIngredients");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ScheduleStartDate",
                table: "Vouchers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 19, 17, 59, 9, 747, DateTimeKind.Local).AddTicks(2999),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 18, 21, 16, 4, 763, DateTimeKind.Local).AddTicks(1781));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Vouchers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 773, DateTimeKind.Local).AddTicks(8106),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 780, DateTimeKind.Local).AddTicks(6012));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 777, DateTimeKind.Local).AddTicks(7837),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 784, DateTimeKind.Local).AddTicks(22));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Meals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 777, DateTimeKind.Local).AddTicks(1020),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 783, DateTimeKind.Local).AddTicks(1651));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 776, DateTimeKind.Local).AddTicks(2343),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 782, DateTimeKind.Local).AddTicks(6432));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Ingredients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 775, DateTimeKind.Local).AddTicks(5020),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 781, DateTimeKind.Local).AddTicks(8680));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "EmployeeInformation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 772, DateTimeKind.Local).AddTicks(9689),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 780, DateTimeKind.Local).AddTicks(2391));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "EmployeeDocuments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 772, DateTimeKind.Local).AddTicks(485),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 779, DateTimeKind.Local).AddTicks(7795));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 774, DateTimeKind.Local).AddTicks(8130),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 780, DateTimeKind.Local).AddTicks(9673));

            migrationBuilder.AlterColumn<string>(
                name: "SpecialNotes",
                table: "Carts",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDateTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 732, DateTimeKind.Local).AddTicks(4522),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 747, DateTimeKind.Local).AddTicks(3338));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 732, DateTimeKind.Local).AddTicks(3863),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 747, DateTimeKind.Local).AddTicks(2607));

            migrationBuilder.CreateTable(
                name: "AddOnContainers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddOnContainers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AddOnItemMeals",
                columns: table => new
                {
                    AddOnContainerId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    MealId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_AddOnItemMeals_AddOnContainers_AddOnContainerId",
                        column: x => x.AddOnContainerId,
                        principalTable: "AddOnContainers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AddOnItemMeals_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AddOnItemMeals_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AddOns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    AddOnContainerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddOns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddOns_AddOnContainers_AddOnContainerId",
                        column: x => x.AddOnContainerId,
                        principalTable: "AddOnContainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AddOnItemMeals_AddOnContainerId",
                table: "AddOnItemMeals",
                column: "AddOnContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_AddOnItemMeals_ItemId",
                table: "AddOnItemMeals",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_AddOnItemMeals_MealId",
                table: "AddOnItemMeals",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_AddOns_AddOnContainerId",
                table: "AddOns",
                column: "AddOnContainerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddOnItemMeals");

            migrationBuilder.DropTable(
                name: "AddOns");

            migrationBuilder.DropTable(
                name: "AddOnContainers");

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
                defaultValue: new DateTime(2024, 9, 18, 21, 16, 4, 763, DateTimeKind.Local).AddTicks(1781),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 19, 17, 59, 9, 747, DateTimeKind.Local).AddTicks(2999));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Vouchers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 780, DateTimeKind.Local).AddTicks(6012),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 773, DateTimeKind.Local).AddTicks(8106));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 784, DateTimeKind.Local).AddTicks(22),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 777, DateTimeKind.Local).AddTicks(7837));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Meals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 783, DateTimeKind.Local).AddTicks(1651),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 777, DateTimeKind.Local).AddTicks(1020));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 782, DateTimeKind.Local).AddTicks(6432),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 776, DateTimeKind.Local).AddTicks(2343));

            migrationBuilder.AddColumn<int>(
                name: "IngredientType",
                table: "ItemIngredients",
                type: "int",
                nullable: false,
                defaultValue: 801);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ItemIngredients",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Ingredients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 781, DateTimeKind.Local).AddTicks(8680),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 775, DateTimeKind.Local).AddTicks(5020));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "EmployeeInformation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 780, DateTimeKind.Local).AddTicks(2391),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 772, DateTimeKind.Local).AddTicks(9689));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "EmployeeDocuments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 779, DateTimeKind.Local).AddTicks(7795),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 772, DateTimeKind.Local).AddTicks(485));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 780, DateTimeKind.Local).AddTicks(9673),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 774, DateTimeKind.Local).AddTicks(8130));

            migrationBuilder.AlterColumn<string>(
                name: "SpecialNotes",
                table: "Carts",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDateTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 747, DateTimeKind.Local).AddTicks(3338),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 732, DateTimeKind.Local).AddTicks(4522));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 18, 21, 15, 44, 747, DateTimeKind.Local).AddTicks(2607),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 19, 17, 58, 49, 732, DateTimeKind.Local).AddTicks(3863));

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
    }
}
