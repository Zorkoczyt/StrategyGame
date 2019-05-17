using Microsoft.EntityFrameworkCore.Migrations;

namespace StrategyGame.Migrations
{
    public partial class Updatebattle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitGroupingType",
                table: "Units");

            migrationBuilder.AddColumn<int>(
                name: "BattleId",
                table: "CountryUnits",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId1",
                table: "CountryUnits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "CountryUnits",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DefendingCountryUnit_BattleId",
                table: "CountryUnits",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefendingCountryUnit_CountryId1",
                table: "CountryUnits",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CountryUnits_BattleId",
                table: "CountryUnits",
                column: "BattleId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryUnits_CountryId1",
                table: "CountryUnits",
                column: "CountryId1");

            migrationBuilder.CreateIndex(
                name: "IX_CountryUnits_DefendingCountryUnit_BattleId",
                table: "CountryUnits",
                column: "DefendingCountryUnit_BattleId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryUnits_DefendingCountryUnit_CountryId1",
                table: "CountryUnits",
                column: "DefendingCountryUnit_CountryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CountryUnits_Battles_BattleId",
                table: "CountryUnits",
                column: "BattleId",
                principalTable: "Battles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryUnits_Countries_CountryId1",
                table: "CountryUnits",
                column: "CountryId1",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryUnits_Battles_BattleId",
                table: "CountryUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryUnits_Countries_CountryId1",
                table: "CountryUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryUnits_Battles_DefendingCountryUnit_BattleId",
                table: "CountryUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryUnits_Countries_DefendingCountryUnit_CountryId1",
                table: "CountryUnits");

            migrationBuilder.DropIndex(
                name: "IX_CountryUnits_BattleId",
                table: "CountryUnits");

            migrationBuilder.DropIndex(
                name: "IX_CountryUnits_CountryId1",
                table: "CountryUnits");

            migrationBuilder.DropIndex(
                name: "IX_CountryUnits_DefendingCountryUnit_BattleId",
                table: "CountryUnits");

            migrationBuilder.DropIndex(
                name: "IX_CountryUnits_DefendingCountryUnit_CountryId1",
                table: "CountryUnits");

            migrationBuilder.DropColumn(
                name: "BattleId",
                table: "CountryUnits");

            migrationBuilder.DropColumn(
                name: "CountryId1",
                table: "CountryUnits");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "CountryUnits");

            migrationBuilder.DropColumn(
                name: "DefendingCountryUnit_BattleId",
                table: "CountryUnits");

            migrationBuilder.DropColumn(
                name: "DefendingCountryUnit_CountryId1",
                table: "CountryUnits");

            migrationBuilder.AddColumn<int>(
                name: "UnitGroupingType",
                table: "Units",
                nullable: false,
                defaultValue: 0);
        }
    }
}
