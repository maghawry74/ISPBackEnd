using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISP.DAL.Migrations
{
    /// <inheritdoc />
    public partial class seeddata3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1",
                column: "NormalizedName",
                value: "SUPERADMIN");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e1d3bd5-ce91-418c-9862-10489040a8fe", "AQAAAAIAAYagAAAAECOJ60IzC+oR0tw/68GQryf/Taq1WufJmfijtgbv1Vee1Gx3lWUEVTdlAL45gr6Y4w==", "3ca0b25e-97eb-4bb4-a774-43d152170fa4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1",
                column: "NormalizedName",
                value: null);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d563d39d-9a7e-4626-96d7-1583249c9a91", "AQAAAAIAAYagAAAAEM99MrKHT4wlSg4OJFJLhmwO9catCew/BwxBDy4kdB7UelzbuE+cGJY6cOilaVzJzg==", "38f91346-f78f-4fd7-810c-c45f25c9f7fe" });
        }
    }
}
