using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestDbCRUD.Migrations
{
    /// <inheritdoc />
    public partial class CompletedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fleet");

            migrationBuilder.DropColumn(
                name: "VehicleQuantity",
                table: "Vehicle");

            migrationBuilder.RenameColumn(
                name: "Condition",
                table: "Vehicle",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Availability",
                table: "Vehicle",
                newName: "Driver");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "Vehicle",
                newName: "Condition");

            migrationBuilder.RenameColumn(
                name: "Driver",
                table: "Vehicle",
                newName: "Availability");

            migrationBuilder.AddColumn<int>(
                name: "VehicleQuantity",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Fleet",
                columns: table => new
                {
                    FleetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Driver = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fleet", x => x.FleetId);
                });
        }
    }
}
