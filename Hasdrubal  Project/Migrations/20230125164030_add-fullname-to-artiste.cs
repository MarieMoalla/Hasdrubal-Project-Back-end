using Microsoft.EntityFrameworkCore.Migrations;

namespace Hasdrubal__Project.Migrations
{
    public partial class addfullnametoartiste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Artistes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Artistes");
        }
    }
}
