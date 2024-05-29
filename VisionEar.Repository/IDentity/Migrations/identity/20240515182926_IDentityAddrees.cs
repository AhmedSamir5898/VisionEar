using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisionEar.Repository.Migrations.identity
{
    public partial class IDentityAddrees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_Addresses_Addressid",
                table: "AppUser");

            migrationBuilder.DropIndex(
                name: "IX_AppUser_Addressid",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "Addressid",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Addresses");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Addresses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ApplicationUserId",
                table: "Addresses",
                column: "ApplicationUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AppUser_ApplicationUserId",
                table: "Addresses",
                column: "ApplicationUserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AppUser_ApplicationUserId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_ApplicationUserId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "Addressid",
                table: "AppUser",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_Addressid",
                table: "AppUser",
                column: "Addressid");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_Addresses_Addressid",
                table: "AppUser",
                column: "Addressid",
                principalTable: "Addresses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
