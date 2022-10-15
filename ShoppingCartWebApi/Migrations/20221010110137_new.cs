using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCartWebApi.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_UserDetails_UserId",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_UserId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cart");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "UserDetails",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MobileNumber",
                table: "UserDetails",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ProductImage",
                table: "Cart",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Cart",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserDetailsUserId",
                table: "Cart",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserDetailsUserId",
                table: "Cart",
                column: "UserDetailsUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_UserDetails_UserDetailsUserId",
                table: "Cart",
                column: "UserDetailsUserId",
                principalTable: "UserDetails",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_UserDetails_UserDetailsUserId",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_UserDetailsUserId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "ProductImage",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "UserDetailsUserId",
                table: "Cart");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "UserDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "MobileNumber",
                table: "UserDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Cart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserId",
                table: "Cart",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_UserDetails_UserId",
                table: "Cart",
                column: "UserId",
                principalTable: "UserDetails",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
