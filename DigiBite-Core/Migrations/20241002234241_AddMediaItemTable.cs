using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigiBite_Core.Migrations
{
    /// <inheritdoc />
    public partial class AddMediaItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Items_ItemId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Meals_MealId",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Medias_ItemId",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Medias_MealId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "IsPrimary",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Medias");

            migrationBuilder.CreateTable(
                name: "MediaItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    MealId = table.Column<int>(type: "int", nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MediaItems_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediaItems_ItemId",
                table: "MediaItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaItems_MealId",
                table: "MediaItems",
                column: "MealId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaItems");

            migrationBuilder.AddColumn<bool>(
                name: "IsPrimary",
                table: "Medias",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Medias",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "Medias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medias_ItemId",
                table: "Medias",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Medias_MealId",
                table: "Medias",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Items_ItemId",
                table: "Medias",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Meals_MealId",
                table: "Medias",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id");
        }
    }
}
