using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestDbCRUD.Migrations
{
    /// <inheritdoc />
    public partial class NewFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "Orders",
                newName: "PickupLocation");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Orders",
                newName: "Destination");

            migrationBuilder.RenameColumn(
                name: "Dimentions",
                table: "Orders",
                newName: "CompanyName");

            migrationBuilder.AddColumn<DateTime>(
                name: "ETA",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ETA",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "PickupLocation",
                table: "Orders",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "Destination",
                table: "Orders",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "Orders",
                newName: "Dimentions");
        }
    }
}
