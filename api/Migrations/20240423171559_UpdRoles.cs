using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class UpdRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "318ad0da-707d-49b7-80a2-e93cc929e17d", null, "Monitor", "MONITOR" },
                    { "da14d7bc-965f-444e-9766-ae00eac977bb", null, "Student", "STUDENT" },
                    { "e9acf298-2184-4ecb-a27e-b459cd203fd3", null, "Deanery", "DEANERY" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "318ad0da-707d-49b7-80a2-e93cc929e17d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da14d7bc-965f-444e-9766-ae00eac977bb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9acf298-2184-4ecb-a27e-b459cd203fd3");

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
    }
}
