using Microsoft.EntityFrameworkCore.Migrations;

namespace StrategyGame.Migrations
{
    public partial class UpdateCountryModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryBuildingProgressId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CountryInnovationProgressId",
                table: "Countries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryBuildingProgressId",
                table: "Countries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryInnovationProgressId",
                table: "Countries",
                nullable: false,
                defaultValue: 0);
        }
    }
}
