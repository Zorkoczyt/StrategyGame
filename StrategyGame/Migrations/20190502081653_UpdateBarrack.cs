using Microsoft.EntityFrameworkCore.Migrations;

namespace StrategyGame.Migrations
{
    public partial class UpdateBarrack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Unit_Building_BarrackId",
                table: "Unit");

            migrationBuilder.DropIndex(
                name: "IX_Unit_BarrackId",
                table: "Unit");

            migrationBuilder.DropColumn(
                name: "BarrackId",
                table: "Unit");

            migrationBuilder.AddColumn<int>(
                name: "Soldiers",
                table: "Building",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Soldiers",
                table: "Building");

            migrationBuilder.AddColumn<int>(
                name: "BarrackId",
                table: "Unit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Unit_BarrackId",
                table: "Unit",
                column: "BarrackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Unit_Building_BarrackId",
                table: "Unit",
                column: "BarrackId",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
