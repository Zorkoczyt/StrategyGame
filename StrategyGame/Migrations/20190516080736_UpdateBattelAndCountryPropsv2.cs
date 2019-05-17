using Microsoft.EntityFrameworkCore.Migrations;

namespace StrategyGame.Migrations
{
    public partial class UpdateBattelAndCountryPropsv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BattleId",
                table: "Countries",
                newName: "AttackBattleId");

            migrationBuilder.AddColumn<int>(
                name: "DefendBattleIdId",
                table: "Countries",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_DefendBattleIdId",
                table: "Countries",
                column: "DefendBattleIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Battles_DefendBattleIdId",
                table: "Countries",
                column: "DefendBattleIdId",
                principalTable: "Battles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Battles_DefendBattleIdId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_DefendBattleIdId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "DefendBattleIdId",
                table: "Countries");

            migrationBuilder.RenameColumn(
                name: "AttackBattleId",
                table: "Countries",
                newName: "BattleId");
        }
    }
}
