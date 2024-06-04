using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class changeAttributes2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "b0de445a-6750-47fc-b85b-845fa2b30551", null, "User", "USER" },
                    { "ec5729f6-64c1-4c4a-8f72-65d0e36a2c1d", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0de445a-6750-47fc-b85b-845fa2b30551");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec5729f6-64c1-4c4a-8f72-65d0e36a2c1d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "398018b5-ca2a-4316-a464-a09f884514f8", null, "User", "USER" },
                    { "db60a7f7-7a3a-4bf2-a5c5-b16594bddb5e", null, "Admin", "ADMIN" }
                });
        }
    }
}
