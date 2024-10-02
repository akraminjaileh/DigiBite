using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigiBite_Core.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAddOn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AddOns",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDateTime",
                table: "AddOns",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "SYSDATETIME()");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "AddOns",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AddOns",
                type: "bit",
                nullable: true,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "AddOns",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDateTime",
                table: "AddOns",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AddOns_ImageId",
                table: "AddOns",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AddOns_Medias_ImageId",
                table: "AddOns",
                column: "ImageId",
                principalTable: "Medias",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddOns_Medias_ImageId",
                table: "AddOns");

            migrationBuilder.DropIndex(
                name: "IX_AddOns_ImageId",
                table: "AddOns");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AddOns");

            migrationBuilder.DropColumn(
                name: "CreationDateTime",
                table: "AddOns");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "AddOns");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AddOns");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "AddOns");

            migrationBuilder.DropColumn(
                name: "LastModifiedDateTime",
                table: "AddOns");
        }
    }
}
