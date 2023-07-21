using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migracija1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCategoryComment = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    StylePath = table.Column<string>(type: "nvarchar(245)", maxLength: 245, nullable: false),
                    CategoryDimensionId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryComments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryDesignArticle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameDesign = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    DesignPath = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryDesignArticle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryDimensions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dimension = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryDimensions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCompany = table.Column<string>(type: "nvarchar(115)", maxLength: 115, nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCountry = table.Column<string>(type: "nvarchar(130)", maxLength: 130, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emotions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEmotion = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emotions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NonRegisteredUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonRegisteredUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRole = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stickers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSticker = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    StickerPath = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stickers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Townships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTownship = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Townships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Townships_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UseCaseRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UseCaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UseCaseRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UseCaseRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameArticle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MainPicturePath = table.Column<string>(type: "nvarchar(220)", maxLength: 220, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(745)", maxLength: 745, nullable: false),
                    AdditionalDescription = table.Column<string>(type: "nvarchar(445)", maxLength: 445, nullable: true),
                    Quote = table.Column<string>(type: "nvarchar(385)", maxLength: 385, nullable: true),
                    MainContent = table.Column<string>(type: "nvarchar(max)", maxLength: 6445, nullable: true),
                    Beggin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CategoryDimensionId = table.Column<int>(type: "int", nullable: false),
                    CategoryDesignArticleId = table.Column<int>(type: "int", nullable: false),
                    NonRegisteredUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_CategoryDesignArticle_CategoryDesignArticleId",
                        column: x => x.CategoryDesignArticleId,
                        principalTable: "CategoryDesignArticle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articles_CategoryDimensions_CategoryDimensionId",
                        column: x => x.CategoryDimensionId,
                        principalTable: "CategoryDimensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articles_NonRegisteredUser_NonRegisteredUserId",
                        column: x => x.NonRegisteredUserId,
                        principalTable: "NonRegisteredUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articles_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCompanies_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCompanies_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArticleImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(245)", maxLength: 245, nullable: false),
                    Alt = table.Column<string>(type: "nvarchar(110)", maxLength: 110, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleImages_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArticleUserEmotions",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EmotionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleUserEmotions", x => new { x.ArticleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ArticleUserEmotions_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArticleUserEmotions_Emotions_EmotionId",
                        column: x => x.EmotionId,
                        principalTable: "Emotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArticleUserEmotions_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommentArticles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(245)", maxLength: 245, nullable: true),
                    ParrentCommentId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    CategoryCommentId = table.Column<int>(type: "int", nullable: false),
                    CategoryDimensionId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentArticles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentArticles_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommentArticles_CategoryComments_CategoryCommentId",
                        column: x => x.CategoryCommentId,
                        principalTable: "CategoryComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommentArticles_CategoryDimensions_CategoryDimensionId",
                        column: x => x.CategoryDimensionId,
                        principalTable: "CategoryDimensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommentArticles_CommentArticles_ParrentCommentId",
                        column: x => x.ParrentCommentId,
                        principalTable: "CommentArticles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommentArticles_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommentArticleStickers_Stickers_StickerId",
                        column: x => x.StickerId,
                        principalTable: "Stickers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleImages_ArticleId",
                table: "ArticleImages",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Beggin",
                table: "Articles",
                column: "Beggin");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryDesignArticleId",
                table: "Articles",
                column: "CategoryDesignArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryDimensionId",
                table: "Articles",
                column: "CategoryDimensionId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_End",
                table: "Articles",
                column: "End");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_NameArticle",
                table: "Articles",
                column: "NameArticle");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_NonRegisteredUserId",
                table: "Articles",
                column: "NonRegisteredUserId",
                unique: true,
                filter: "[NonRegisteredUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleUserEmotions_EmotionId",
                table: "ArticleUserEmotions",
                column: "EmotionId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleUserEmotions_UserId",
                table: "ArticleUserEmotions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryComments_NameCategoryComment",
                table: "CategoryComments",
                column: "NameCategoryComment",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryDesignArticle_NameDesign",
                table: "CategoryDesignArticle",
                column: "NameDesign",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryDimensions_Dimension",
                table: "CategoryDimensions",
                column: "Dimension",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentArticles_ArticleId",
                table: "CommentArticles",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentArticles_CategoryCommentId",
                table: "CommentArticles",
                column: "CategoryCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentArticles_CategoryDimensionId",
                table: "CommentArticles",
                column: "CategoryDimensionId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentArticles_ParrentCommentId",
                table: "CommentArticles",
                column: "ParrentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentArticles_UserId",
                table: "CommentArticles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentArticleStickers_StickerId",
                table: "CommentArticleStickers",
                column: "StickerId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_NameCompany",
                table: "Companies",
                column: "NameCompany",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_NameCountry",
                table: "Countries",
                column: "NameCountry",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emotions_NameEmotion",
                table: "Emotions",
                column: "NameEmotion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_NameRole",
                table: "Roles",
                column: "NameRole",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stickers_NameSticker",
                table: "Stickers",
                column: "NameSticker",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Townships_CountryId",
                table: "Townships",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Townships_NameTownship",
                table: "Townships",
                column: "NameTownship",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UseCaseRole_RoleId",
                table: "UseCaseRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_FirstName",
                table: "User",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "IX_User_LastName",
                table: "User",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCompanies_CompanyId",
                table: "UserCompanies",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCompanies_UserId",
                table: "UserCompanies",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleImages");

            migrationBuilder.DropTable(
                name: "ArticleUserEmotions");

            migrationBuilder.DropTable(
                name: "CommentArticleStickers");

            migrationBuilder.DropTable(
                name: "Townships");

            migrationBuilder.DropTable(
                name: "UseCaseRole");

            migrationBuilder.DropTable(
                name: "UserCompanies");

            migrationBuilder.DropTable(
                name: "Emotions");

            migrationBuilder.DropTable(
                name: "CommentArticles");

            migrationBuilder.DropTable(
                name: "Stickers");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "CategoryComments");

            migrationBuilder.DropTable(
                name: "CategoryDesignArticle");

            migrationBuilder.DropTable(
                name: "CategoryDimensions");

            migrationBuilder.DropTable(
                name: "NonRegisteredUser");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
