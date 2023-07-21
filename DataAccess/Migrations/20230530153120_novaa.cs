using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class novaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_CategoryDesignArticle_CategoryDesignArticleId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_NonRegisteredUser_NonRegisteredUserId",
                table: "Articles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NonRegisteredUser",
                table: "NonRegisteredUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryDesignArticle",
                table: "CategoryDesignArticle");

            migrationBuilder.RenameTable(
                name: "NonRegisteredUser",
                newName: "NonRegisteredUsers");

            migrationBuilder.RenameTable(
                name: "CategoryDesignArticle",
                newName: "CategoryDesignArticles");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryDesignArticle_NameDesign",
                table: "CategoryDesignArticles",
                newName: "IX_CategoryDesignArticles_NameDesign");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NonRegisteredUsers",
                table: "NonRegisteredUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryDesignArticles",
                table: "CategoryDesignArticles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_CategoryDesignArticles_CategoryDesignArticleId",
                table: "Articles",
                column: "CategoryDesignArticleId",
                principalTable: "CategoryDesignArticles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_NonRegisteredUsers_NonRegisteredUserId",
                table: "Articles",
                column: "NonRegisteredUserId",
                principalTable: "NonRegisteredUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_CategoryDesignArticles_CategoryDesignArticleId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_NonRegisteredUsers_NonRegisteredUserId",
                table: "Articles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NonRegisteredUsers",
                table: "NonRegisteredUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryDesignArticles",
                table: "CategoryDesignArticles");

            migrationBuilder.RenameTable(
                name: "NonRegisteredUsers",
                newName: "NonRegisteredUser");

            migrationBuilder.RenameTable(
                name: "CategoryDesignArticles",
                newName: "CategoryDesignArticle");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryDesignArticles_NameDesign",
                table: "CategoryDesignArticle",
                newName: "IX_CategoryDesignArticle_NameDesign");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NonRegisteredUser",
                table: "NonRegisteredUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryDesignArticle",
                table: "CategoryDesignArticle",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_CategoryDesignArticle_CategoryDesignArticleId",
                table: "Articles",
                column: "CategoryDesignArticleId",
                principalTable: "CategoryDesignArticle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_NonRegisteredUser_NonRegisteredUserId",
                table: "Articles",
                column: "NonRegisteredUserId",
                principalTable: "NonRegisteredUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
