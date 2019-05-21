using Microsoft.EntityFrameworkCore.Migrations;

namespace StrategyGame.Migrations
{
    public partial class FixCitiwall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Innovations",
                keyColumn: "Id",
                keyValue: 3,
                column: "Point",
                value: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Innovations",
                keyColumn: "Id",
                keyValue: 3,
                column: "Point",
                value: 0);
        }
    }
}
