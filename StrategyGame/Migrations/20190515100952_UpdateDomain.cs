using Microsoft.EntityFrameworkCore.Migrations;

namespace StrategyGame.Migrations
{
    public partial class UpdateDomain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryUnits_Battles_DefendingCountryUnit_BattleId",
                table: "CountryUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryUnits_Countries_DefendingCountryUnit_CountryId1",
                table: "CountryUnits");

            migrationBuilder.DropIndex(
                name: "IX_CountryUnits_DefendingCountryUnit_BattleId",
                table: "CountryUnits");

            migrationBuilder.DropColumn(
                name: "DefendingCountryUnit_BattleId",
                table: "CountryUnits");

            migrationBuilder.RenameColumn(
                name: "DefendingCountryUnit_CountryId1",
                table: "CountryUnits",
                newName: "BattleId1");

            migrationBuilder.RenameIndex(
                name: "IX_CountryUnits_DefendingCountryUnit_CountryId1",
                table: "CountryUnits",
                newName: "IX_CountryUnits_BattleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CountryUnits_Battles_BattleId1",
                table: "CountryUnits",
                column: "BattleId1",
                principalTable: "Battles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryUnits_Battles_BattleId1",
                table: "CountryUnits");

            migrationBuilder.RenameColumn(
                name: "BattleId1",
                table: "CountryUnits",
                newName: "DefendingCountryUnit_CountryId1");

            migrationBuilder.RenameIndex(
                name: "IX_CountryUnits_BattleId1",
                table: "CountryUnits",
                newName: "IX_CountryUnits_DefendingCountryUnit_CountryId1");

            migrationBuilder.AddColumn<int>(
                name: "DefendingCountryUnit_BattleId",
                table: "CountryUnits",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CountryUnits_DefendingCountryUnit_BattleId",
                table: "CountryUnits",
                column: "DefendingCountryUnit_BattleId");

            migrationBuilder.AddForeignKey(
                name: "FK_CountryUnits_Battles_DefendingCountryUnit_BattleId",
                table: "CountryUnits",
                column: "DefendingCountryUnit_BattleId",
                principalTable: "Battles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryUnits_Countries_DefendingCountryUnit_CountryId1",
                table: "CountryUnits",
                column: "DefendingCountryUnit_CountryId1",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
