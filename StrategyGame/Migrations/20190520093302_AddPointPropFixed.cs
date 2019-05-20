using Microsoft.EntityFrameworkCore.Migrations;

namespace StrategyGame.Migrations
{
    public partial class AddPointPropFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Point",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Point",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Innovations",
                keyColumn: "Id",
                keyValue: 6,
                column: "Point",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Innovations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Point",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Innovations",
                keyColumn: "Id",
                keyValue: 4,
                column: "Point",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Innovations",
                keyColumn: "Id",
                keyValue: 5,
                column: "Point",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Innovations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Point",
                value: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Point",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Point",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Innovations",
                keyColumn: "Id",
                keyValue: 6,
                column: "Point",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Innovations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Point",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Innovations",
                keyColumn: "Id",
                keyValue: 4,
                column: "Point",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Innovations",
                keyColumn: "Id",
                keyValue: 5,
                column: "Point",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Innovations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Point",
                value: 0);
        }
    }
}
