using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigiBite_Core.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAddOnContainer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AddOnContainers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDateTime",
                table: "AddOnContainers",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "SYSDATETIME()");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AddOnContainers",
                type: "bit",
                nullable: true,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "AddOnContainers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDateTime",
                table: "AddOnContainers",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AddOnContainers");

            migrationBuilder.DropColumn(
                name: "CreationDateTime",
                table: "AddOnContainers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AddOnContainers");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "AddOnContainers");

            migrationBuilder.DropColumn(
                name: "LastModifiedDateTime",
                table: "AddOnContainers");
        }
    }
}
