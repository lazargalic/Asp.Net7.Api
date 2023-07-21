using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migracija3IzmenaNazivaTabele : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_User_UserId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleUserEmotions_User_UserId",
                table: "ArticleUserEmotions");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentArticles_User_UserId",
                table: "CommentArticles");

            migrationBuilder.DropForeignKey(
                name: "FK_UseCaseRole_Roles_RoleId",
                table: "UseCaseRole");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Roles_RoleId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanies_User_UserId",
                table: "UserCompanies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UseCaseRole",
                table: "UseCaseRole");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "UseCaseRole",
                newName: "UseCaseRoles");

            migrationBuilder.RenameIndex(
                name: "IX_User_RoleId",
                table: "Users",
                newName: "IX_Users_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_User_LastName",
                table: "Users",
                newName: "IX_Users_LastName");

            migrationBuilder.RenameIndex(
                name: "IX_User_FirstName",
                table: "Users",
                newName: "IX_Users_FirstName");

            migrationBuilder.RenameIndex(
                name: "IX_User_Email",
                table: "Users",
                newName: "IX_Users_Email");

            migrationBuilder.RenameIndex(
                name: "IX_UseCaseRole_RoleId",
                table: "UseCaseRoles",
                newName: "IX_UseCaseRoles_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UseCaseRoles",
                table: "UseCaseRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Users_UserId",
                table: "Articles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleUserEmotions_Users_UserId",
                table: "ArticleUserEmotions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentArticles_Users_UserId",
                table: "CommentArticles",
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

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanies_Users_UserId",
                table: "UserCompanies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Users_UserId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleUserEmotions_Users_UserId",
                table: "ArticleUserEmotions");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentArticles_Users_UserId",
                table: "CommentArticles");

            migrationBuilder.DropForeignKey(
                name: "FK_UseCaseRoles_Roles_RoleId",
                table: "UseCaseRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanies_Users_UserId",
                table: "UserCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UseCaseRoles",
                table: "UseCaseRoles");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "UseCaseRoles",
                newName: "UseCaseRole");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleId",
                table: "User",
                newName: "IX_User_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_LastName",
                table: "User",
                newName: "IX_User_LastName");

            migrationBuilder.RenameIndex(
                name: "IX_Users_FirstName",
                table: "User",
                newName: "IX_User_FirstName");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Email",
                table: "User",
                newName: "IX_User_Email");

            migrationBuilder.RenameIndex(
                name: "IX_UseCaseRoles_RoleId",
                table: "UseCaseRole",
                newName: "IX_UseCaseRole_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UseCaseRole",
                table: "UseCaseRole",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_User_UserId",
                table: "Articles",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleUserEmotions_User_UserId",
                table: "ArticleUserEmotions",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentArticles_User_UserId",
                table: "CommentArticles",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UseCaseRole_Roles_RoleId",
                table: "UseCaseRole",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Roles_RoleId",
                table: "User",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanies_User_UserId",
                table: "UserCompanies",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
