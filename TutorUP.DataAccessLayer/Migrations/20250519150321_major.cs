using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutorUP.DataAccessLayer.Migrations
{
    public partial class major : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Major",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Major",
                table: "AspNetUsers");
        }
    }
}
