using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestDbCRUD.Migrations
{
    /// <inheritdoc />
    public partial class Frontendandstatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "UserStatus",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserStatus",
                table: "Orders");
        }
    }
}
