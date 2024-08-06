using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestDbCRUD.Migrations
{
    /// <inheritdoc />
    public partial class Roleaddition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccount_RoleType_RoleID",
                table: "UserAccount");

            migrationBuilder.AlterColumn<int>(
                name: "RoleID",
                table: "UserAccount",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccount_RoleType_RoleID",
                table: "UserAccount",
                column: "RoleID",
                principalTable: "RoleType",
                principalColumn: "RoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccount_RoleType_RoleID",
                table: "UserAccount");

            migrationBuilder.AlterColumn<int>(
                name: "RoleID",
                table: "UserAccount",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccount_RoleType_RoleID",
                table: "UserAccount",
                column: "RoleID",
                principalTable: "RoleType",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
