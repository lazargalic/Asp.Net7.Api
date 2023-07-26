using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migracijaKoloneCena : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Emotions");

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "CommentArticles",
                type: "float",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "AuditLogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 24, 20, 8, 32, 346, DateTimeKind.Local).AddTicks(6656),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 1, 22, 4, 7, 597, DateTimeKind.Local).AddTicks(6222));

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "Articles",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "CommentArticles");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Articles");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Emotions",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "AuditLogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 1, 22, 4, 7, 597, DateTimeKind.Local).AddTicks(6222),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 24, 20, 8, 32, 346, DateTimeKind.Local).AddTicks(6656));
        }
    }
}
