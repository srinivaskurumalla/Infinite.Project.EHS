using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EHS_API.Migrations
{
    public partial class AppDbChangedToHouseImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_House_Sellers_SellerId",
                table: "House");

            migrationBuilder.DropForeignKey(
                name: "FK_HouseImage_House_HouseId",
                table: "HouseImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HouseImage",
                table: "HouseImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_House",
                table: "House");

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

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "HouseImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_HouseImages",
                table: "HouseImages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Houses",
                table: "Houses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HouseImages_Houses_HouseId",
                table: "HouseImages",
                column: "HouseId",
                principalTable: "Houses",
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
                name: "FK_Houses_Sellers_SellerId",
                table: "Houses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Houses",
                table: "Houses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HouseImages",
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

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "HouseImage",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_House",
                table: "House",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HouseImage",
                table: "HouseImage",
                column: "Id");

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
        }
    }
}
