using Microsoft.EntityFrameworkCore.Migrations;

namespace GithubAPI.Migrations
{
    public partial class ChangeFKREview2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Pull_Id",
                table: "Review");

            migrationBuilder.AddColumn<int>(
                name: "PullId",
                table: "Review",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Review_PullId",
                table: "Review",
                column: "PullId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Pull_PullId",
                table: "Review",
                column: "PullId",
                principalTable: "Pull",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Pull_PullId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_PullId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "PullId",
                table: "Review");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Pull_Id",
                table: "Review",
                column: "Id",
                principalTable: "Pull",
                principalColumn: "Id");
        }
    }
}
