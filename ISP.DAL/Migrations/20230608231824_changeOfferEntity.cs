using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISP.DAL.Migrations
{
    /// <inheritdoc />
    public partial class changeOfferEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Providers_providerId",
                table: "Offers");

            migrationBuilder.RenameColumn(
                name: "providerId",
                table: "Offers",
                newName: "ProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_Offers_providerId",
                table: "Offers",
                newName: "IX_Offers_ProviderId");

            migrationBuilder.AlterColumn<int>(
                name: "ProviderId",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Providers_ProviderId",
                table: "Offers",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Providers_ProviderId",
                table: "Offers");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "Offers",
                newName: "providerId");

            migrationBuilder.RenameIndex(
                name: "IX_Offers_ProviderId",
                table: "Offers",
                newName: "IX_Offers_providerId");

            migrationBuilder.AlterColumn<int>(
                name: "providerId",
                table: "Offers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Providers_providerId",
                table: "Offers",
                column: "providerId",
                principalTable: "Providers",
                principalColumn: "Id");
        }
    }
}
