using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Migracija2TownshipRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TownshipId",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_TownshipId",
                table: "Articles",
                column: "TownshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Townships_TownshipId",
                table: "Articles",
                column: "TownshipId",
                principalTable: "Townships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Townships_TownshipId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_TownshipId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "TownshipId",
                table: "Articles");
        }
    }
}
