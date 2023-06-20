using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISP.DAL.Migrations
{
    /// <inheritdoc />
    public partial class seeddata2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d563d39d-9a7e-4626-96d7-1583249c9a91", "AQAAAAIAAYagAAAAEM99MrKHT4wlSg4OJFJLhmwO9catCew/BwxBDy4kdB7UelzbuE+cGJY6cOilaVzJzg==", "38f91346-f78f-4fd7-810c-c45f25c9f7fe" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db82f84b-ff5d-4b95-b6bf-57597cd6531f", "AQAAAAIAAYagAAAAEJRlbrkjrHuzVLYPnth5xbKUZN7lCQB5/9VM5vjZeSOhiowtf5DhOGG2dtetfu9sBQ==", "bf8d8a55-f074-4894-98c5-b03eb59e8ed8" });
        }
    }
}
