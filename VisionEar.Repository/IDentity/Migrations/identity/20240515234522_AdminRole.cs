using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisionEar.Repository.Migrations.identity
{
    public partial class AdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1856ceea-4975-4d87-919f-9afa6c3fe1b2", "96a74b3d-0614-48f6-8dc3-0c7ca32bdcd9", "User", "user" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "914ba55e-57b3-4bb5-9c41-5c14f25d5a71", "ef649c9f-6eee-4c4c-a251-d7ecfa47c4c1", "Admin", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1856ceea-4975-4d87-919f-9afa6c3fe1b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "914ba55e-57b3-4bb5-9c41-5c14f25d5a71");
        }
    }
}
