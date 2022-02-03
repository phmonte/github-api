using Microsoft.EntityFrameworkCore.Migrations;

namespace GithubAPI.Migrations
{
    public partial class AddFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ReviewSearched",
                table: "Pull",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReviewSearched",
                table: "Pull");
        }
    }
}
