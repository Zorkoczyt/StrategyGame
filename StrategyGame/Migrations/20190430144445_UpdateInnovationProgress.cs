using Microsoft.EntityFrameworkCore.Migrations;

namespace StrategyGame.Migrations
{
    public partial class UpdateInnovationProgress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CountryInnovationProgress",
                newName: "CountryInnovationProgressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CountryInnovationProgressId",
                table: "CountryInnovationProgress",
                newName: "Id");
        }
    }
}
