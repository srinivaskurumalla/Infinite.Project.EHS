using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EHS_API.Migrations
{
    public partial class fixinpasswordhash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_House_Sellers_SellerId",
                table: "House");

            migrationBuilder.DropForeignKey(
                name: "FK_HouseImage_House_HouseId",
                table: "HouseImage");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RolesId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Sellers_SellerId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RolesId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SellerId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HouseImage",
                table: "HouseImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_House",
                table: "House");

            migrationBuilder.DropColumn(
                name: "RolesId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "HouseImage");

            migrationBuilder.RenameTable(
                name: "HouseImage",
                newName: "HouseImages");

            migrationBuilder.RenameTable(
                name: "House",
                newName: "Houses");

            migrationBuilder.RenameIndex(
                name: "IX_HouseImage_HouseId",
                table: "HouseImages",
                newName: "IX_HouseImages_HouseId");

            migrationBuilder.RenameIndex(
                name: "IX_House_SellerId",
                table: "Houses",
                newName: "IX_Houses_SellerId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Sellers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "HouseImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "HouseImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Region",
                table: "Houses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PropertyType",
                table: "Houses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PropertyOption",
                table: "Houses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PropertyName",
                table: "Houses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Houses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Houses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Houses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HouseImages",
                table: "HouseImages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Houses",
                table: "Houses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleMpping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserDetailsId = table.Column<int>(type: "int", nullable: false),
                    UserRolesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleMpping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoleMpping_Roles_UserRolesId",
                        column: x => x.UserRolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleMpping_Users_UserDetailsId",
                        column: x => x.UserDetailsId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Houses_CityId",
                table: "Houses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMpping_UserDetailsId_UserRolesId",
                table: "UserRoleMpping",
                columns: new[] { "UserDetailsId", "UserRolesId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMpping_UserRolesId",
                table: "UserRoleMpping",
                column: "UserRolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_HouseImages_Houses_HouseId",
                table: "HouseImages",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_Cities_CityId",
                table: "Houses",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_Sellers_SellerId",
                table: "Houses",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HouseImages_Houses_HouseId",
                table: "HouseImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Houses_Cities_CityId",
                table: "Houses");

            migrationBuilder.DropForeignKey(
                name: "FK_Houses_Sellers_SellerId",
                table: "Houses");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "UserRoleMpping");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Houses",
                table: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Houses_CityId",
                table: "Houses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HouseImages",
                table: "HouseImages");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "HouseImages");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "HouseImages");

            migrationBuilder.RenameTable(
                name: "Houses",
                newName: "House");

            migrationBuilder.RenameTable(
                name: "HouseImages",
                newName: "HouseImage");

            migrationBuilder.RenameIndex(
                name: "IX_Houses_SellerId",
                table: "House",
                newName: "IX_House_SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_HouseImages_HouseId",
                table: "HouseImage",
                newName: "IX_HouseImage_HouseId");

            migrationBuilder.AddColumn<int>(
                name: "RolesId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Region",
                table: "House",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PropertyType",
                table: "House",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PropertyOption",
                table: "House",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PropertyName",
                table: "House",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "House",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "HouseImage",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_House",
                table: "House",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HouseImage",
                table: "HouseImage",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RolesId",
                table: "Users",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SellerId",
                table: "Users",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_House_Sellers_SellerId",
                table: "House",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HouseImage_House_HouseId",
                table: "HouseImage",
                column: "HouseId",
                principalTable: "House",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RolesId",
                table: "Users",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Sellers_SellerId",
                table: "Users",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
