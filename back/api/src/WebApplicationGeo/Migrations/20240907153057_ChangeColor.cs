using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationGeo.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Areas_AreaId",
                table: "Cities");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Colors",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_RegionCapitalId",
                table: "Areas",
                column: "RegionCapitalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Cities_RegionCapitalId",
                table: "Areas",
                column: "RegionCapitalId",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Areas_AreaId",
                table: "Cities",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Cities_RegionCapitalId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Areas_AreaId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Areas_RegionCapitalId",
                table: "Areas");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Colors",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Areas_AreaId",
                table: "Cities",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
