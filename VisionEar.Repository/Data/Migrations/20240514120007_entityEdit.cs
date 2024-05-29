using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisionEar.Repository.Data.Migrations
{
    public partial class entityEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "category_name");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Brands",
                newName: "brand_name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "category_name",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "brand_name",
                table: "Brands",
                newName: "Name");
        }
    }
}
