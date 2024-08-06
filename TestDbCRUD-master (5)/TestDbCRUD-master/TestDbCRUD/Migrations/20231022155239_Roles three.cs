using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestDbCRUD.Migrations
{
    /// <inheritdoc />
    public partial class Rolesthree : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccount_RoleType_RoleID",
                table: "UserAccount");

            migrationBuilder.RenameColumn(
                name: "RoleID",
                table: "UserAccount",
                newName: "RoleName");

            migrationBuilder.RenameIndex(
                name: "IX_UserAccount_RoleID",
                table: "UserAccount",
                newName: "IX_UserAccount_RoleName");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccount_RoleType_RoleName",
                table: "UserAccount",
                column: "RoleName",
                principalTable: "RoleType",
                principalColumn: "RoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccount_RoleType_RoleName",
                table: "UserAccount");

            migrationBuilder.RenameColumn(
                name: "RoleName",
                table: "UserAccount",
                newName: "RoleID");

            migrationBuilder.RenameIndex(
                name: "IX_UserAccount_RoleName",
                table: "UserAccount",
                newName: "IX_UserAccount_RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccount_RoleType_RoleID",
                table: "UserAccount",
                column: "RoleID",
                principalTable: "RoleType",
                principalColumn: "RoleID");
        }
    }
}
