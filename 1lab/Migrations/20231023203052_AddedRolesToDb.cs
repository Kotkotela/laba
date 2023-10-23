using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _1lab.Migrations
{
    /// <inheritdoc />
    public partial class AddedRolesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "62453655-65d1-47e8-97e6-3bd390542d73", "7d8f37a2-6349-4ac2-9ebb-df139d0185ae", "Administrator", "ADMINISTRATOR" },
                    { "c865de79-a383-4bf8-bf80-e3df2045e1be", "bb717499-7756-4cf9-ac3b-19e46987cf5c", "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62453655-65d1-47e8-97e6-3bd390542d73");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c865de79-a383-4bf8-bf80-e3df2045e1be");
        }
    }
}
