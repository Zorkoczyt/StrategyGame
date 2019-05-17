using Microsoft.EntityFrameworkCore.Migrations;

namespace StrategyGame.Migrations
{
    public partial class UpdateCountryWithList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Countries",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AttackingCountryId",
                table: "Battles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DefendingCountryId",
                table: "Battles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CountryId",
                table: "Countries",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Countries_CountryId",
                table: "Countries",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Countries_CountryId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_CountryId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "AttackingCountryId",
                table: "Battles");

            migrationBuilder.DropColumn(
                name: "DefendingCountryId",
                table: "Battles");
        }
    }
}
