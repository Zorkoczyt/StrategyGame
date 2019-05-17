using Microsoft.EntityFrameworkCore.Migrations;

namespace StrategyGame.Migrations
{
    public partial class AddInitialDataToInnovation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Innovations",
                columns: new[] { "Id", "Discriminator", "UpgradeStat" },
                values: new object[,]
                {
                    { 6, "Alchemy", 1.3 },
                    { 3, "CityWall", 1.2 },
                    { 2, "Combine", 1.15 },
                    { 4, "OperationRebirth", 1.2 },
                    { 5, "Tactic", 1.1 },
                    { 1, "Truck", 1.1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Innovations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Innovations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Innovations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Innovations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Innovations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Innovations",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
