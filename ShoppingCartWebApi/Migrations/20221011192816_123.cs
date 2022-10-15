using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCartWebApi.Migrations
{
    public partial class _123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_feedback",
                table: "feedback");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "feedback");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "feedback",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_feedback",
                table: "feedback",
                column: "Username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_feedback",
                table: "feedback");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "feedback");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "feedback",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_feedback",
                table: "feedback",
                column: "UserId");
        }
    }
}
