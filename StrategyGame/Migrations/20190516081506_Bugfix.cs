using Microsoft.EntityFrameworkCore.Migrations;

namespace StrategyGame.Migrations
{
    public partial class Bugfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "DefendBattleId",
                table: "Countries",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefendBattleId",
                table: "Countries");

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
    }
}
