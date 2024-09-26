using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigiBite_Core.Migrations
{
    /// <inheritdoc />
    public partial class AddIsInMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsAvailable",
                table: "Meals",
                type: "bit",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsInMenu",
                table: "Meals",
                type: "bit",
                nullable: true,
                defaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsAvailable",
                table: "Items",
                type: "bit",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsInMenu",
                table: "Items",
                type: "bit",
                nullable: true,
                defaultValue: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7ca5a1c-2e4b-4c8d-84fd-d9f011ad0a5b",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEOehifwSlf/f/SwTWoiLkHyw8lAR+hVc+AAbnJO92WWdCBaFAvBfSfnPv84Hn+lVmQ==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInMenu",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "IsInMenu",
                table: "Items");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAvailable",
                table: "Meals",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsAvailable",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7ca5a1c-2e4b-4c8d-84fd-d9f011ad0a5b",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBs+11uy6aesq/nlo/5q+koJ0JBQBugZD9qNJnCqxyM8rR7lt+HSNVGrI1/jTWHqMQ==");
        }
    }
}
