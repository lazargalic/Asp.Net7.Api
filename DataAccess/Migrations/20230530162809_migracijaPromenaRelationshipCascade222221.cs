using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migracijaPromenaRelationshipCascade222221 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleImages_Articles_ArticleId",
                table: "ArticleImages");

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
                name: "FK_CommentArticleStickers_CommentArticles_CommentArticleId",
                table: "CommentArticleStickers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanies_Users_UserId",
                table: "UserCompanies");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleImages_Articles_ArticleId",
                table: "ArticleImages",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Users_UserId",
                table: "Articles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleUserEmotions_Users_UserId",
                table: "ArticleUserEmotions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentArticles_Users_UserId",
                table: "CommentArticles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentArticleStickers_CommentArticles_CommentArticleId",
                table: "CommentArticleStickers",
                column: "CommentArticleId",
                principalTable: "CommentArticles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanies_Users_UserId",
                table: "UserCompanies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleImages_Articles_ArticleId",
                table: "ArticleImages");

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
                name: "FK_CommentArticleStickers_CommentArticles_CommentArticleId",
                table: "CommentArticleStickers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanies_Users_UserId",
                table: "UserCompanies");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleImages_Articles_ArticleId",
                table: "ArticleImages",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_CommentArticleStickers_CommentArticles_CommentArticleId",
                table: "CommentArticleStickers",
                column: "CommentArticleId",
                principalTable: "CommentArticles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanies_Users_UserId",
                table: "UserCompanies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
