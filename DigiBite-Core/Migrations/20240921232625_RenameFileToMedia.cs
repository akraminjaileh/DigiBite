using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigiBite_Core.Migrations
{
    /// <inheritdoc />
    public partial class RenameFileToMedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Images_ProfileImgId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Images_ImageId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Items_ItemId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Meals_MealId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Images_ImageId",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "Medias");

            migrationBuilder.RenameIndex(
                name: "IX_Images_MealId",
                table: "Medias",
                newName: "IX_Medias_MealId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_ItemId",
                table: "Medias",
                newName: "IX_Medias_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_ImageUrl",
                table: "Medias",
                newName: "IX_Medias_ImageUrl");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medias",
                table: "Medias",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7ca5a1c-2e4b-4c8d-84fd-d9f011ad0a5b",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBs+11uy6aesq/nlo/5q+koJ0JBQBugZD9qNJnCqxyM8rR7lt+HSNVGrI1/jTWHqMQ==");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Medias_ProfileImgId",
                table: "AspNetUsers",
                column: "ProfileImgId",
                principalTable: "Medias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Medias_ImageId",
                table: "Categories",
                column: "ImageId",
                principalTable: "Medias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Medias_ImageId",
                table: "Ingredients",
                column: "ImageId",
                principalTable: "Medias",
                principalColumn: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Medias_ProfileImgId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Medias_ImageId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Medias_ImageId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Items_ItemId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Meals_MealId",
                table: "Medias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medias",
                table: "Medias");

            migrationBuilder.RenameTable(
                name: "Medias",
                newName: "Images");

            migrationBuilder.RenameIndex(
                name: "IX_Medias_MealId",
                table: "Images",
                newName: "IX_Images_MealId");

            migrationBuilder.RenameIndex(
                name: "IX_Medias_ItemId",
                table: "Images",
                newName: "IX_Images_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Medias_ImageUrl",
                table: "Images",
                newName: "IX_Images_ImageUrl");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7ca5a1c-2e4b-4c8d-84fd-d9f011ad0a5b",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEB5miEfAN3YgyC3qqRnkEzOr5dtLJ1Pq/XYekMjeDaWf6sVJd+7wICicjT2yVqyozw==");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Images_ProfileImgId",
                table: "AspNetUsers",
                column: "ProfileImgId",
                principalTable: "Images",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Images_ImageId",
                table: "Categories",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Items_ItemId",
                table: "Images",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Meals_MealId",
                table: "Images",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Images_ImageId",
                table: "Ingredients",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }
    }
}
