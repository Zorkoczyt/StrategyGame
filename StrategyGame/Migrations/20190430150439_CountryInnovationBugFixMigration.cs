using Microsoft.EntityFrameworkCore.Migrations;

namespace StrategyGame.Migrations
{
    public partial class CountryInnovationBugFixMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_CountryInnovationProgress_CountryInnovationProgressId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_CountryInnovationProgressId",
                table: "Countries");

            migrationBuilder.RenameColumn(
                name: "CounryId",
                table: "CountryInnovationProgress",
                newName: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryInnovationProgress_CountryId",
                table: "CountryInnovationProgress",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CountryInnovationProgress_Countries_CountryId",
                table: "CountryInnovationProgress",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryInnovationProgress_Countries_CountryId",
                table: "CountryInnovationProgress");

            migrationBuilder.DropIndex(
                name: "IX_CountryInnovationProgress_CountryId",
                table: "CountryInnovationProgress");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "CountryInnovationProgress",
                newName: "CounryId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CountryInnovationProgressId",
                table: "Countries",
                column: "CountryInnovationProgressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_CountryInnovationProgress_CountryInnovationProgressId",
                table: "Countries",
                column: "CountryInnovationProgressId",
                principalTable: "CountryInnovationProgress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
