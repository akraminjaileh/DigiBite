using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigiBite_Core.Migrations
{
    /// <inheritdoc />
    public partial class userNameReq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7ca5a1c-2e4b-4c8d-84fd-d9f011ad0a5b",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEDHj0XJdb7BXCuHfnjHAqqks5VVF+ToiFmfM7K8d11XEGHeqgVrYG1h4PZ9lWiT0/A==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7ca5a1c-2e4b-4c8d-84fd-d9f011ad0a5b",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEJBli493LHSGq6Y2GpOozFFMSPO5JcHdpViiU1Oq020cpHqoLaId9ZA6XOhr5AXbuQ==");
        }
    }
}
