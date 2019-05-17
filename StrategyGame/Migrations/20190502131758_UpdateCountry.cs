using Microsoft.EntityFrameworkCore.Migrations;

namespace StrategyGame.Migrations
{
    public partial class UpdateCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryBuilding_Building_BuildingId",
                table: "CountryBuilding");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryBuilding_Countries_CountryId",
                table: "CountryBuilding");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryBuildingProgress_Building_BuildingId",
                table: "CountryBuildingProgress");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryBuildingProgress_Countries_CountryId",
                table: "CountryBuildingProgress");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryInnovation_Countries_CountryId",
                table: "CountryInnovation");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryInnovation_Innovation_InnovationId",
                table: "CountryInnovation");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryInnovationProgress_Countries_CountryId",
                table: "CountryInnovationProgress");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryInnovationProgress_Innovation_InnovationId",
                table: "CountryInnovationProgress");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryUnit_Countries_CountryId",
                table: "CountryUnit");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryUnit_Unit_UnitId",
                table: "CountryUnit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Unit",
                table: "Unit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Innovation",
                table: "Innovation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountryUnit",
                table: "CountryUnit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountryInnovationProgress",
                table: "CountryInnovationProgress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountryInnovation",
                table: "CountryInnovation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountryBuildingProgress",
                table: "CountryBuildingProgress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountryBuilding",
                table: "CountryBuilding");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Building",
                table: "Building");

            migrationBuilder.RenameTable(
                name: "Unit",
                newName: "Units");

            migrationBuilder.RenameTable(
                name: "Innovation",
                newName: "Innovations");

            migrationBuilder.RenameTable(
                name: "CountryUnit",
                newName: "CountryUnits");

            migrationBuilder.RenameTable(
                name: "CountryInnovationProgress",
                newName: "CountryInnovationProgresses");

            migrationBuilder.RenameTable(
                name: "CountryInnovation",
                newName: "CountryInnovations");

            migrationBuilder.RenameTable(
                name: "CountryBuildingProgress",
                newName: "CountryBuildingProgresses");

            migrationBuilder.RenameTable(
                name: "CountryBuilding",
                newName: "CountryBuildings");

            migrationBuilder.RenameTable(
                name: "Building",
                newName: "Buildings");

            migrationBuilder.RenameIndex(
                name: "IX_CountryUnit_UnitId",
                table: "CountryUnits",
                newName: "IX_CountryUnits_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_CountryUnit_CountryId",
                table: "CountryUnits",
                newName: "IX_CountryUnits_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_CountryInnovationProgress_InnovationId",
                table: "CountryInnovationProgresses",
                newName: "IX_CountryInnovationProgresses_InnovationId");

            migrationBuilder.RenameIndex(
                name: "IX_CountryInnovationProgress_CountryId",
                table: "CountryInnovationProgresses",
                newName: "IX_CountryInnovationProgresses_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_CountryInnovation_InnovationId",
                table: "CountryInnovations",
                newName: "IX_CountryInnovations_InnovationId");

            migrationBuilder.RenameIndex(
                name: "IX_CountryInnovation_CountryId",
                table: "CountryInnovations",
                newName: "IX_CountryInnovations_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_CountryBuildingProgress_CountryId",
                table: "CountryBuildingProgresses",
                newName: "IX_CountryBuildingProgresses_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_CountryBuildingProgress_BuildingId",
                table: "CountryBuildingProgresses",
                newName: "IX_CountryBuildingProgresses_BuildingId");

            migrationBuilder.RenameIndex(
                name: "IX_CountryBuilding_CountryId",
                table: "CountryBuildings",
                newName: "IX_CountryBuildings_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_CountryBuilding_BuildingId",
                table: "CountryBuildings",
                newName: "IX_CountryBuildings_BuildingId");

            migrationBuilder.AlterColumn<double>(
                name: "Point",
                table: "Countries",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<double>(
                name: "Gold",
                table: "Countries",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Potato",
                table: "Countries",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Units",
                table: "Units",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Innovations",
                table: "Innovations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountryUnits",
                table: "CountryUnits",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountryInnovationProgresses",
                table: "CountryInnovationProgresses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountryInnovations",
                table: "CountryInnovations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountryBuildingProgresses",
                table: "CountryBuildingProgresses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountryBuildings",
                table: "CountryBuildings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buildings",
                table: "Buildings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CountryBuildingProgresses_Buildings_BuildingId",
                table: "CountryBuildingProgresses",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryBuildingProgresses_Countries_CountryId",
                table: "CountryBuildingProgresses",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryBuildings_Buildings_BuildingId",
                table: "CountryBuildings",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryBuildings_Countries_CountryId",
                table: "CountryBuildings",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryInnovationProgresses_Countries_CountryId",
                table: "CountryInnovationProgresses",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryInnovationProgresses_Innovations_InnovationId",
                table: "CountryInnovationProgresses",
                column: "InnovationId",
                principalTable: "Innovations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryInnovations_Countries_CountryId",
                table: "CountryInnovations",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryInnovations_Innovations_InnovationId",
                table: "CountryInnovations",
                column: "InnovationId",
                principalTable: "Innovations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryUnits_Countries_CountryId",
                table: "CountryUnits",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryUnits_Units_UnitId",
                table: "CountryUnits",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryBuildingProgresses_Buildings_BuildingId",
                table: "CountryBuildingProgresses");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryBuildingProgresses_Countries_CountryId",
                table: "CountryBuildingProgresses");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryBuildings_Buildings_BuildingId",
                table: "CountryBuildings");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryBuildings_Countries_CountryId",
                table: "CountryBuildings");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryInnovationProgresses_Countries_CountryId",
                table: "CountryInnovationProgresses");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryInnovationProgresses_Innovations_InnovationId",
                table: "CountryInnovationProgresses");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryInnovations_Countries_CountryId",
                table: "CountryInnovations");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryInnovations_Innovations_InnovationId",
                table: "CountryInnovations");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryUnits_Countries_CountryId",
                table: "CountryUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryUnits_Units_UnitId",
                table: "CountryUnits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Units",
                table: "Units");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Innovations",
                table: "Innovations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountryUnits",
                table: "CountryUnits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountryInnovations",
                table: "CountryInnovations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountryInnovationProgresses",
                table: "CountryInnovationProgresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountryBuildings",
                table: "CountryBuildings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountryBuildingProgresses",
                table: "CountryBuildingProgresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buildings",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "Gold",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Potato",
                table: "Countries");

            migrationBuilder.RenameTable(
                name: "Units",
                newName: "Unit");

            migrationBuilder.RenameTable(
                name: "Innovations",
                newName: "Innovation");

            migrationBuilder.RenameTable(
                name: "CountryUnits",
                newName: "CountryUnit");

            migrationBuilder.RenameTable(
                name: "CountryInnovations",
                newName: "CountryInnovation");

            migrationBuilder.RenameTable(
                name: "CountryInnovationProgresses",
                newName: "CountryInnovationProgress");

            migrationBuilder.RenameTable(
                name: "CountryBuildings",
                newName: "CountryBuilding");

            migrationBuilder.RenameTable(
                name: "CountryBuildingProgresses",
                newName: "CountryBuildingProgress");

            migrationBuilder.RenameTable(
                name: "Buildings",
                newName: "Building");

            migrationBuilder.RenameIndex(
                name: "IX_CountryUnits_UnitId",
                table: "CountryUnit",
                newName: "IX_CountryUnit_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_CountryUnits_CountryId",
                table: "CountryUnit",
                newName: "IX_CountryUnit_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_CountryInnovations_InnovationId",
                table: "CountryInnovation",
                newName: "IX_CountryInnovation_InnovationId");

            migrationBuilder.RenameIndex(
                name: "IX_CountryInnovations_CountryId",
                table: "CountryInnovation",
                newName: "IX_CountryInnovation_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_CountryInnovationProgresses_InnovationId",
                table: "CountryInnovationProgress",
                newName: "IX_CountryInnovationProgress_InnovationId");

            migrationBuilder.RenameIndex(
                name: "IX_CountryInnovationProgresses_CountryId",
                table: "CountryInnovationProgress",
                newName: "IX_CountryInnovationProgress_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_CountryBuildings_CountryId",
                table: "CountryBuilding",
                newName: "IX_CountryBuilding_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_CountryBuildings_BuildingId",
                table: "CountryBuilding",
                newName: "IX_CountryBuilding_BuildingId");

            migrationBuilder.RenameIndex(
                name: "IX_CountryBuildingProgresses_CountryId",
                table: "CountryBuildingProgress",
                newName: "IX_CountryBuildingProgress_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_CountryBuildingProgresses_BuildingId",
                table: "CountryBuildingProgress",
                newName: "IX_CountryBuildingProgress_BuildingId");

            migrationBuilder.AlterColumn<int>(
                name: "Point",
                table: "Countries",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Unit",
                table: "Unit",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Innovation",
                table: "Innovation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountryUnit",
                table: "CountryUnit",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountryInnovation",
                table: "CountryInnovation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountryInnovationProgress",
                table: "CountryInnovationProgress",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountryBuilding",
                table: "CountryBuilding",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountryBuildingProgress",
                table: "CountryBuildingProgress",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Building",
                table: "Building",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CountryBuilding_Building_BuildingId",
                table: "CountryBuilding",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryBuilding_Countries_CountryId",
                table: "CountryBuilding",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryBuildingProgress_Building_BuildingId",
                table: "CountryBuildingProgress",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryBuildingProgress_Countries_CountryId",
                table: "CountryBuildingProgress",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryInnovation_Countries_CountryId",
                table: "CountryInnovation",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryInnovation_Innovation_InnovationId",
                table: "CountryInnovation",
                column: "InnovationId",
                principalTable: "Innovation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryInnovationProgress_Countries_CountryId",
                table: "CountryInnovationProgress",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryInnovationProgress_Innovation_InnovationId",
                table: "CountryInnovationProgress",
                column: "InnovationId",
                principalTable: "Innovation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryUnit_Countries_CountryId",
                table: "CountryUnit",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryUnit_Unit_UnitId",
                table: "CountryUnit",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
