using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigiBite_Core.Migrations
{
    /// <inheritdoc />
    public partial class PriceType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Items",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7ca5a1c-2e4b-4c8d-84fd-d9f011ad0a5b",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEAaw+JzUtxf4UxYqLBUib/N8Z3BZWW551LsFcXbxlXdaUCkVrRKFQ4MJjRbC5PCBIQ==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7ca5a1c-2e4b-4c8d-84fd-d9f011ad0a5b",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEOehifwSlf/f/SwTWoiLkHyw8lAR+hVc+AAbnJO92WWdCBaFAvBfSfnPv84Hn+lVmQ==");
        }
    }
}
