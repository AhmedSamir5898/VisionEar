using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisionEar.Repository.Migrations.identity
{
    public partial class IDentityEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AppUser_ApplicationUserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_AspNetUsers_Id",
                table: "AppUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUser",
                table: "AppUser");

            migrationBuilder.RenameTable(
                name: "AppUser",
                newName: "ApplicationUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUser",
                table: "ApplicationUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_ApplicationUser_ApplicationUserId",
                table: "Addresses",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_AspNetUsers_Id",
                table: "ApplicationUser",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_ApplicationUser_ApplicationUserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_AspNetUsers_Id",
                table: "ApplicationUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUser",
                table: "ApplicationUser");

            migrationBuilder.RenameTable(
                name: "ApplicationUser",
                newName: "AppUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUser",
                table: "AppUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AppUser_ApplicationUserId",
                table: "Addresses",
                column: "ApplicationUserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_AspNetUsers_Id",
                table: "AppUser",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
