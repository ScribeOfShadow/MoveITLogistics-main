using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestDbCRUD.Migrations
{
    /// <inheritdoc />
    public partial class Role : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleID",
                table: "UserAccount",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RoleType",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleType", x => x.RoleID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_RoleID",
                table: "UserAccount",
                column: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccount_RoleType_RoleID",
                table: "UserAccount",
                column: "RoleID",
                principalTable: "RoleType",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccount_RoleType_RoleID",
                table: "UserAccount");

            migrationBuilder.DropTable(
                name: "RoleType");

            migrationBuilder.DropIndex(
                name: "IX_UserAccount_RoleID",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "UserAccount");
        }
    }
}
