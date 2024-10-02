using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigiBite_Core.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Medias");

            migrationBuilder.AddColumn<int>(
                name: "SizeKB",
                table: "Medias",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SizeKB",
                table: "Medias");

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Medias",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Size",
                table: "Medias",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "Medias",
                type: "int",
                nullable: true);
        }
    }
}
