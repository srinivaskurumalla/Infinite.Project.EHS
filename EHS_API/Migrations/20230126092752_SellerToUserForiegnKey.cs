using Microsoft.EntityFrameworkCore.Migrations;

namespace EHS_API.Migrations
{
    public partial class SellerToUserForiegnKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_SellerId",
                table: "Users",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Sellers_SellerId",
                table: "Users",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Sellers_SellerId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SellerId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Users");
        }
    }
}
