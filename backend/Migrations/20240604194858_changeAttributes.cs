using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class changeAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1432b224-1ed8-4bec-865b-4d02dface405");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ff6831b-78c6-461a-8bb3-f2d1d3d90f9b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "398018b5-ca2a-4316-a464-a09f884514f8", null, "User", "USER" },
                    { "db60a7f7-7a3a-4bf2-a5c5-b16594bddb5e", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "398018b5-ca2a-4316-a464-a09f884514f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db60a7f7-7a3a-4bf2-a5c5-b16594bddb5e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1432b224-1ed8-4bec-865b-4d02dface405", null, "Admin", "ADMIN" },
                    { "5ff6831b-78c6-461a-8bb3-f2d1d3d90f9b", null, "User", "USER" }
                });
        }
    }
}
