using Microsoft.EntityFrameworkCore.Migrations;

namespace EHS_API.Migrations
{
    public partial class RemovedSellerIdFromState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_States_Sellers_sellerId",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_States_sellerId",
                table: "States");

            migrationBuilder.DropColumn(
                name: "sellerId",
                table: "States");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "sellerId",
                table: "States",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_States_sellerId",
                table: "States",
                column: "sellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_States_Sellers_sellerId",
                table: "States",
                column: "sellerId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
