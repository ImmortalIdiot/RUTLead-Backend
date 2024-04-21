using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25a68119-9cf0-4acd-9819-49e9b7073fe4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f41bb1fe-9ea6-4db6-b1af-f014fc0c9a2f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4177a936-ff8a-4971-b3d4-3b140207dd4c", null, "Monitor", "MONITOR" },
                    { "abc9bebe-efe2-4476-8596-6fcb74a5b955", null, "Student", "STUDENT" },
                    { "fa7c9cbf-aef5-438d-98b4-d3641de48d0f", null, "GroupLeader", "GROUPLEADER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4177a936-ff8a-4971-b3d4-3b140207dd4c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abc9bebe-efe2-4476-8596-6fcb74a5b955");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa7c9cbf-aef5-438d-98b4-d3641de48d0f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "25a68119-9cf0-4acd-9819-49e9b7073fe4", null, "Admin", "ADMIN" },
                    { "f41bb1fe-9ea6-4db6-b1af-f014fc0c9a2f", null, "User", "USER" }
                });
        }
    }
}
