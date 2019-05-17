using Microsoft.EntityFrameworkCore.Migrations;

namespace StrategyGame.Migrations
{
    public partial class fixBattleProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Battles_AttackingCountryId",
                table: "Battles",
                column: "AttackingCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Battles_DefendingCountryId",
                table: "Battles",
                column: "DefendingCountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Battles_Countries_AttackingCountryId",
                table: "Battles",
                column: "AttackingCountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Battles_Countries_DefendingCountryId",
                table: "Battles",
                column: "DefendingCountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Battles_Countries_AttackingCountryId",
                table: "Battles");

            migrationBuilder.DropForeignKey(
                name: "FK_Battles_Countries_DefendingCountryId",
                table: "Battles");

            migrationBuilder.DropIndex(
                name: "IX_Battles_AttackingCountryId",
                table: "Battles");

            migrationBuilder.DropIndex(
                name: "IX_Battles_DefendingCountryId",
                table: "Battles");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Countries",
                nullable: true);

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
    }
}
