using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StrategyGame.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Innovation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UpgradeStat = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Innovation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<int>(nullable: false),
                    AttackPoint = table.Column<int>(nullable: false),
                    DefensePoint = table.Column<int>(nullable: false),
                    Payment = table.Column<int>(nullable: false),
                    Supply = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryInnovationProgress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TurnsLeft = table.Column<int>(nullable: false),
                    CounryId = table.Column<int>(nullable: false),
                    InnovationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryInnovationProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryInnovationProgress_Innovation_InnovationId",
                        column: x => x.InnovationId,
                        principalTable: "Innovation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Point = table.Column<int>(nullable: false),
                    CountryBuildingProgressId = table.Column<int>(nullable: false),
                    CountryInnovationProgressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_CountryInnovationProgress_CountryInnovationProgressId",
                        column: x => x.CountryInnovationProgressId,
                        principalTable: "CountryInnovationProgress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryBuilding",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryId = table.Column<int>(nullable: false),
                    BuildingId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryBuilding", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryBuilding_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Building",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryBuilding_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryBuildingProgress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TurnsLeft = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    BuildingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryBuildingProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryBuildingProgress_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Building",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryBuildingProgress_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryInnovation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryId = table.Column<int>(nullable: false),
                    InnovationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryInnovation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryInnovation_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryInnovation_Innovation_InnovationId",
                        column: x => x.InnovationId,
                        principalTable: "Innovation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CountryUnit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryId = table.Column<int>(nullable: false),
                    UnitId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryUnit_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryUnit_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CountryInnovationProgressId",
                table: "Countries",
                column: "CountryInnovationProgressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CountryBuilding_BuildingId",
                table: "CountryBuilding",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryBuilding_CountryId",
                table: "CountryBuilding",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryBuildingProgress_BuildingId",
                table: "CountryBuildingProgress",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryBuildingProgress_CountryId",
                table: "CountryBuildingProgress",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryInnovation_CountryId",
                table: "CountryInnovation",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryInnovation_InnovationId",
                table: "CountryInnovation",
                column: "InnovationId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryInnovationProgress_InnovationId",
                table: "CountryInnovationProgress",
                column: "InnovationId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryUnit_CountryId",
                table: "CountryUnit",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryUnit_UnitId",
                table: "CountryUnit",
                column: "UnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryBuilding");

            migrationBuilder.DropTable(
                name: "CountryBuildingProgress");

            migrationBuilder.DropTable(
                name: "CountryInnovation");

            migrationBuilder.DropTable(
                name: "CountryUnit");

            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "CountryInnovationProgress");

            migrationBuilder.DropTable(
                name: "Innovation");
        }
    }
}
