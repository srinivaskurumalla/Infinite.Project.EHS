using Microsoft.EntityFrameworkCore.Migrations;

namespace EHS_API.Migrations
{
    public partial class RelatedSellerCityState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "sellerId",
                table: "States",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Sellers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_States_sellerId",
                table: "States",
                column: "sellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_CityId",
                table: "Sellers",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_Cities_CityId",
                table: "Sellers",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_States_Sellers_sellerId",
                table: "States",
                column: "sellerId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_Cities_CityId",
                table: "Sellers");

            migrationBuilder.DropForeignKey(
                name: "FK_States_Sellers_sellerId",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_States_sellerId",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_Sellers_CityId",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "sellerId",
                table: "States");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Sellers");
        }
    }
}
