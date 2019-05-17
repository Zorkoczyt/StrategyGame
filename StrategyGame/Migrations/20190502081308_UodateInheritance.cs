using Microsoft.EntityFrameworkCore.Migrations;

namespace StrategyGame.Migrations
{
    public partial class UodateInheritance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BarrackId",
                table: "Unit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Innovation",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "Building",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Building",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Population",
                table: "Building",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Potato",
                table: "Building",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Innovation");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Building");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Building");

            migrationBuilder.DropColumn(
                name: "Population",
                table: "Building");

            migrationBuilder.DropColumn(
                name: "Potato",
                table: "Building");
        }
    }
}
