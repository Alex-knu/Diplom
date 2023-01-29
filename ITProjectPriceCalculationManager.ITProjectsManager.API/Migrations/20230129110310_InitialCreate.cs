using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Profit = table.Column<double>(type: "double precision", nullable: false),
                    Overhead = table.Column<double>(type: "double precision", nullable: false),
                    SocialInsurance = table.Column<double>(type: "double precision", nullable: false),
                    AverageCostLabor = table.Column<double>(type: "double precision", nullable: false),
                    AverageMonthlyRateWorkingHours = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgramLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SLOC = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectAreaElements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    SubjectAreaType = table.Column<int>(type: "integer", maxLength: 256, nullable: false),
                    DifficultyLevelsType = table.Column<int>(type: "integer", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectAreaElements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgramsParametrs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SLOC = table.Column<int>(type: "integer", nullable: false),
                    ProgramLanguageId = table.Column<int>(type: "integer", nullable: false),
                    ApplicationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramsParametrs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramsParametrs_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramsParametrs_ProgramLanguages_ProgramLanguageId",
                        column: x => x.ProgramLanguageId,
                        principalTable: "ProgramLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramsParametrToSubjectAreaElements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProgramsParametrId = table.Column<int>(type: "integer", nullable: false),
                    SubjectAreaElementId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramsParametrToSubjectAreaElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramsParametrToSubjectAreaElements_ProgramsParametrs_Pro~",
                        column: x => x.ProgramsParametrId,
                        principalTable: "ProgramsParametrs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramsParametrToSubjectAreaElements_SubjectAreaElements_S~",
                        column: x => x.SubjectAreaElementId,
                        principalTable: "SubjectAreaElements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramsParametrs_ApplicationId",
                table: "ProgramsParametrs",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramsParametrs_ProgramLanguageId",
                table: "ProgramsParametrs",
                column: "ProgramLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramsParametrToSubjectAreaElements_ProgramsParametrId",
                table: "ProgramsParametrToSubjectAreaElements",
                column: "ProgramsParametrId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramsParametrToSubjectAreaElements_SubjectAreaElementId",
                table: "ProgramsParametrToSubjectAreaElements",
                column: "SubjectAreaElementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramsParametrToSubjectAreaElements");

            migrationBuilder.DropTable(
                name: "ProgramsParametrs");

            migrationBuilder.DropTable(
                name: "SubjectAreaElements");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "ProgramLanguages");
        }
    }
}
