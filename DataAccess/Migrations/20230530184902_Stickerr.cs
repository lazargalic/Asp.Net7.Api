using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Stickerr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentArticleStickers");

            migrationBuilder.AddColumn<int>(
                name: "StickerId",
                table: "CommentArticles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CommentArticles_StickerId",
                table: "CommentArticles",
                column: "StickerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentArticles_Stickers_StickerId",
                table: "CommentArticles",
                column: "StickerId",
                principalTable: "Stickers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentArticles_Stickers_StickerId",
                table: "CommentArticles");

            migrationBuilder.DropIndex(
                name: "IX_CommentArticles_StickerId",
                table: "CommentArticles");

            migrationBuilder.DropColumn(
                name: "StickerId",
                table: "CommentArticles");

            migrationBuilder.CreateTable(
                name: "CommentArticleStickers",
                columns: table => new
                {
                    CommentArticleId = table.Column<int>(type: "int", nullable: false),
                    StickerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentArticleStickers", x => new { x.CommentArticleId, x.StickerId });
                    table.ForeignKey(
                        name: "FK_CommentArticleStickers_CommentArticles_CommentArticleId",
                        column: x => x.CommentArticleId,
                        principalTable: "CommentArticles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentArticleStickers_Stickers_StickerId",
                        column: x => x.StickerId,
                        principalTable: "Stickers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentArticleStickers_StickerId",
                table: "CommentArticleStickers",
                column: "StickerId");
        }
    }
}
