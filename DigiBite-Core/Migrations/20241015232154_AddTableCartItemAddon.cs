using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigiBite_Core.Migrations
{
    /// <inheritdoc />
    public partial class AddTableCartItemAddon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Ingredients_IngredientId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_IngredientId",
                table: "CartItems");

            migrationBuilder.DropCheckConstraint(
                name: "CH_CartItem_QTY",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "ItemPrice",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "SpecialNotes",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "QTY",
                table: "CartItems",
                newName: "Quantity");

            migrationBuilder.AddColumn<int>(
                name: "Unit",
                table: "ItemIngredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ItemPrice",
                table: "CartItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "SpecialNotes",
                table: "CartItems",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CartItemAddons",
                columns: table => new
                {
                    CartItemId = table.Column<int>(type: "int", nullable: false),
                    AddonId = table.Column<int>(type: "int", nullable: false),
                    AddonPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItemAddons", x => new { x.AddonId, x.CartItemId });
                    table.ForeignKey(
                        name: "FK_CartItemAddons_AddOns_AddonId",
                        column: x => x.AddonId,
                        principalTable: "AddOns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItemAddons_CartItems_CartItemId",
                        column: x => x.CartItemId,
                        principalTable: "CartItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddCheckConstraint(
                name: "CH_CartItem_Quantity",
                table: "CartItems",
                sql: "Quantity > 0");

            migrationBuilder.CreateIndex(
                name: "IX_CartItemAddons_CartItemId",
                table: "CartItemAddons",
                column: "CartItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItemAddons");

            migrationBuilder.DropCheckConstraint(
                name: "CH_CartItem_Quantity",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "ItemIngredients");

            migrationBuilder.DropColumn(
                name: "ItemPrice",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "SpecialNotes",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "CartItems",
                newName: "QTY");

            migrationBuilder.AddColumn<int>(
                name: "Unit",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 152);

            migrationBuilder.AddColumn<decimal>(
                name: "ItemPrice",
                table: "Carts",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Carts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialNotes",
                table: "Carts",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                table: "CartItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_IngredientId",
                table: "CartItems",
                column: "IngredientId");

            migrationBuilder.AddCheckConstraint(
                name: "CH_CartItem_QTY",
                table: "CartItems",
                sql: "QTY > 0");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Ingredients_IngredientId",
                table: "CartItems",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id");
        }
    }
}
