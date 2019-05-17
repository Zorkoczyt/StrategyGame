using Microsoft.EntityFrameworkCore.Migrations;

namespace StrategyGame.Migrations
{
    public partial class AddInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "AttackPoint", "DefensePoint", "Discriminator", "Payment", "Price", "Supply" },
                values: new object[] { 1, 2, 6, "Archer", 1, 50, 1 });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "AttackPoint", "DefensePoint", "Discriminator", "Payment", "Price", "Supply" },
                values: new object[] { 3, 5, 5, "Elit", 3, 100, 2 });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "AttackPoint", "DefensePoint", "Discriminator", "Payment", "Price", "Supply" },
                values: new object[] { 2, 6, 2, "Horseman", 1, 50, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
