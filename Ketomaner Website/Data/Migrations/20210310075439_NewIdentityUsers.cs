using Microsoft.EntityFrameworkCore.Migrations;

namespace Ketomaner_Website.Data.Migrations
{
    public partial class NewIdentityUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TEST",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TEST",
                table: "AspNetUsers");
        }
    }
}
