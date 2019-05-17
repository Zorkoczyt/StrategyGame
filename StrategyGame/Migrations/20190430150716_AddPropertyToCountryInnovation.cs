using Microsoft.EntityFrameworkCore.Migrations;

namespace StrategyGame.Migrations
{
    public partial class AddPropertyToCountryInnovation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryInnovation_Innovation_InnovationId",
                table: "CountryInnovation");

            migrationBuilder.AlterColumn<int>(
                name: "InnovationId",
                table: "CountryInnovation",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryInnovation_Innovation_InnovationId",
                table: "CountryInnovation",
                column: "InnovationId",
                principalTable: "Innovation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryInnovation_Innovation_InnovationId",
                table: "CountryInnovation");

            migrationBuilder.AlterColumn<int>(
                name: "InnovationId",
                table: "CountryInnovation",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_CountryInnovation_Innovation_InnovationId",
                table: "CountryInnovation",
                column: "InnovationId",
                principalTable: "Innovation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
