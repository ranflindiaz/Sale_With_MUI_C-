using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaleWithMaui.API.Migrations
{
    /// <inheritdoc />
    public partial class AddStatesAndCitiesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_States_Countries_CountryId",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_States_CountryId",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_States_Name_CountryId",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_Cities_Name_StateId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_StateId",
                table: "Cities");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "States",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId_Name",
                table: "States",
                columns: new[] { "CountryId", "Name" },
                unique: true,
                filter: "[CountryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId_Name",
                table: "Cities",
                columns: new[] { "StateId", "Name" },
                unique: true,
                filter: "[StateId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_States_Countries_CountryId",
                table: "States",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_States_Countries_CountryId",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_States_CountryId_Name",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_Cities_StateId_Name",
                table: "Cities");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "States",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_States_Name_CountryId",
                table: "States",
                columns: new[] { "Name", "CountryId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Name_StateId",
                table: "Cities",
                columns: new[] { "Name", "StateId" },
                unique: true,
                filter: "[StateId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_States_Countries_CountryId",
                table: "States",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
