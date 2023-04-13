using Microsoft.EntityFrameworkCore.Migrations;

namespace EHS_API.Migrations
{
    public partial class UniqueConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserRoleMpping_UserDetailsId",
                table: "UserRoleMpping");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMpping_UserDetailsId_UserRolesId",
                table: "UserRoleMpping",
                columns: new[] { "UserDetailsId", "UserRolesId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserRoleMpping_UserDetailsId_UserRolesId",
                table: "UserRoleMpping");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMpping_UserDetailsId",
                table: "UserRoleMpping",
                column: "UserDetailsId");
        }
    }
}
