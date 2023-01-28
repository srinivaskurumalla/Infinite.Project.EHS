using Microsoft.EntityFrameworkCore.Migrations;

namespace EHS_API.Migrations
{
    public partial class Changeduserdetailsagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_Sellers_SellerId",
                table: "Houses");

            migrationBuilder.DropTable(
                name: "Sellers");

            migrationBuilder.RenameColumn(
                name: "SellerId",
                table: "Houses",
                newName: "UserDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_Houses_SellerId",
                table: "Houses",
                newName: "IX_Houses_UserDetailsId");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_Users_UserDetailsId",
                table: "Houses",
                column: "UserDetailsId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_Users_UserDetailsId",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserDetailsId",
                table: "Houses",
                newName: "SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_Houses_UserDetailsId",
                table: "Houses",
                newName: "IX_Houses_SellerId");

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_Sellers_SellerId",
                table: "Houses",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
