using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migracijaguidverificationCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VerificationCode",
                table: "Users",
                type: "nvarchar(340)",
                maxLength: 340,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "AuditLogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 26, 1, 11, 27, 941, DateTimeKind.Local).AddTicks(7989),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 24, 20, 8, 32, 346, DateTimeKind.Local).AddTicks(6656));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VerificationCode",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "AuditLogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 24, 20, 8, 32, 346, DateTimeKind.Local).AddTicks(6656),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 26, 1, 11, 27, 941, DateTimeKind.Local).AddTicks(7989));
        }
    }
}
