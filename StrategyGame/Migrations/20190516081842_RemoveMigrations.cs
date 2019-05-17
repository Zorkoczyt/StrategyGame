using Microsoft.EntityFrameworkCore.Migrations;

namespace StrategyGame.Migrations
{
    public partial class RemoveMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "AttackBattleId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "DefendBattleId",
                table: "Countries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttackBattleId",
                table: "Countries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DefendBattleId",
                table: "Countries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Battles_AttackingCountryId",
                table: "Battles",
                column: "AttackingCountryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Battles_DefendingCountryId",
                table: "Battles",
                column: "DefendingCountryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Battles_Countries_AttackingCountryId",
                table: "Battles",
                column: "AttackingCountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Battles_Countries_DefendingCountryId",
                table: "Battles",
                column: "DefendingCountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
