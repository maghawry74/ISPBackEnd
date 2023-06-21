using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISP.DAL.Migrations
{
    /// <inheritdoc />
    public partial class seeddata4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb2e62e4-8869-4691-b76f-ba16b713a748", "REEM", "AQAAAAIAAYagAAAAEJp7C055x1yo/1tZgGnuYkIWEHcv/6r/+Qyy1aj9wUK8Paew+Kd+5t9cOUbvtakuJQ==", "6d51ff86-1440-40c9-b1ab-d41a5a16dd7e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e1d3bd5-ce91-418c-9862-10489040a8fe", null, "AQAAAAIAAYagAAAAECOJ60IzC+oR0tw/68GQryf/Taq1WufJmfijtgbv1Vee1Gx3lWUEVTdlAL45gr6Y4w==", "3ca0b25e-97eb-4bb4-a774-43d152170fa4" });
        }
    }
}
