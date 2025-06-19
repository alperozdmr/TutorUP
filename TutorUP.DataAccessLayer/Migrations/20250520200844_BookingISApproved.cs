using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutorUP.DataAccessLayer.Migrations
{
    public partial class BookingISApproved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "BookALessons",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "BookALessons");
        }
    }
}
