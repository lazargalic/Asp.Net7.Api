using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migracija6cascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllUserUseCases_Users_UserId",
                table: "AllUserUseCases");

            migrationBuilder.DropForeignKey(
                name: "FK_UseCaseRoles_Roles_RoleId",
                table: "UseCaseRoles");

            migrationBuilder.AddForeignKey(
                name: "FK_AllUserUseCases_Users_UserId",
                table: "AllUserUseCases",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UseCaseRoles_Roles_RoleId",
                table: "UseCaseRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllUserUseCases_Users_UserId",
                table: "AllUserUseCases");

            migrationBuilder.DropForeignKey(
                name: "FK_UseCaseRoles_Roles_RoleId",
                table: "UseCaseRoles");

            migrationBuilder.AddForeignKey(
                name: "FK_AllUserUseCases_Users_UserId",
                table: "AllUserUseCases",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UseCaseRoles_Roles_RoleId",
                table: "UseCaseRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
