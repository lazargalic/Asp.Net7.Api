using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migracijaguidverificationCodecolumnnotdefaulttrue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "AuditLogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 26, 1, 58, 13, 358, DateTimeKind.Local).AddTicks(8881),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 26, 1, 11, 27, 941, DateTimeKind.Local).AddTicks(7989));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "AuditLogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 26, 1, 11, 27, 941, DateTimeKind.Local).AddTicks(7989),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 26, 1, 58, 13, 358, DateTimeKind.Local).AddTicks(8881));
        }
    }
}
