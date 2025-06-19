using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutorUP.DataAccessLayer.Migrations
{
    public partial class forumımg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "ForumPosts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "ForumPosts");
        }
    }
}
