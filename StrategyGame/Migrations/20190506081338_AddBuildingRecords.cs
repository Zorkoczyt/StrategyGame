using Microsoft.EntityFrameworkCore.Migrations;

namespace StrategyGame.Migrations
{
    public partial class AddBuildingRecords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "Discriminator", "Soldiers" },
                values: new object[] { 2, "Barrack", 0 });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "Discriminator", "Population", "Potato" },
                values: new object[] { 1, "Farm", 0, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
