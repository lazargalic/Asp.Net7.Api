using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migracijaaaaaaaaaaaaaa : Migration  
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Ovo sam morao rucno da dodam nije sam video promenu 
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Articles",
                nullable: true,  
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
