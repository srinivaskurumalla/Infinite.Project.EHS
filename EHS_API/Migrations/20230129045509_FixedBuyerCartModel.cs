using Microsoft.EntityFrameworkCore.Migrations;

namespace EHS_API.Migrations
{
    public partial class FixedBuyerCartModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserDetaisId",
                table: "BuyerCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BuyerCarts_UserDetaisId_HouseId",
                table: "BuyerCarts",
                columns: new[] { "UserDetaisId", "HouseId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BuyerCarts_Users_UserDetaisId",
                table: "BuyerCarts",
                column: "UserDetaisId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyerCarts_Users_UserDetaisId",
                table: "BuyerCarts");

            migrationBuilder.DropIndex(
                name: "IX_BuyerCarts_UserDetaisId_HouseId",
                table: "BuyerCarts");

            migrationBuilder.DropColumn(
                name: "UserDetaisId",
                table: "BuyerCarts");
        }
    }
}
