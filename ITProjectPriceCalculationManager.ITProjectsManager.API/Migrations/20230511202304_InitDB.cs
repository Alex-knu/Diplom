using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ParentId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_Department_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Department",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DifficultyLevelsTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DifficultyLevelsTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FactorTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactorTypes", x => x.Id);
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
                name: "Estimators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estimators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estimators_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DifficultyLevelsTypeToFactorTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DifficultyLevelId = table.Column<int>(type: "integer", nullable: false),
                    FactorTypeId = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DifficultyLevelsTypeToFactorTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DifficultyLevelsTypeToFactorTypes_DifficultyLevelsTypes_Dif~",
                        column: x => x.DifficultyLevelId,
                        principalTable: "DifficultyLevelsTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DifficultyLevelsTypeToFactorTypes_FactorTypes_FactorTypeId",
                        column: x => x.FactorTypeId,
                        principalTable: "FactorTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatorId = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Profit = table.Column<double>(type: "double precision", nullable: false),
                    Overhead = table.Column<double>(type: "double precision", nullable: false),
                    SocialInsurance = table.Column<double>(type: "double precision", nullable: false),
                    AverageCostLabor = table.Column<double>(type: "double precision", nullable: false),
                    AverageMonthlyRateWorkingHours = table.Column<double>(type: "double precision", nullable: false),
                    ConfidenceArea = table.Column<double>(type: "double precision", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_Estimators_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Estimators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AttributeId = table.Column<int>(type: "integer", nullable: false),
                    EstimatorId = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profile_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profile_Estimators_EstimatorId",
                        column: x => x.EstimatorId,
                        principalTable: "Estimators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationToEstimators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationId = table.Column<int>(type: "integer", nullable: false),
                    EstimatorId = table.Column<int>(type: "integer", nullable: false),
                    SelfEvaluation = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationToEstimators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationToEstimators_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationToEstimators_Estimators_EstimatorId",
                        column: x => x.EstimatorId,
                        principalTable: "Estimators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationToFactors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationId = table.Column<int>(type: "integer", nullable: false),
                    FactorId = table.Column<int>(type: "integer", nullable: false),
                    FactorTypeId = table.Column<int>(type: "integer", nullable: false),
                    DifficultyLevelId = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationToFactors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationToFactors_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationToFactors_Attributes_FactorId",
                        column: x => x.FactorId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationToFactors_DifficultyLevelsTypes_DifficultyLevelId",
                        column: x => x.DifficultyLevelId,
                        principalTable: "DifficultyLevelsTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationToFactors_FactorTypes_FactorTypeId",
                        column: x => x.FactorTypeId,
                        principalTable: "FactorTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramsParametrs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                name: "EvaluatorToEvaluatedFactors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EvaluatorId = table.Column<int>(type: "integer", nullable: false),
                    EvaluatedFactorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluatorToEvaluatedFactors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluatorToEvaluatedFactors_ApplicationToFactors_EvaluatedF~",
                        column: x => x.EvaluatedFactorId,
                        principalTable: "ApplicationToFactors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvaluatorToEvaluatedFactors_Estimators_EvaluatorId",
                        column: x => x.EvaluatorId,
                        principalTable: "Estimators",
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
                        name: "FK_ProgramsParametrToSubjectAreaElements_ApplicationToFactors_~",
                        column: x => x.SubjectAreaElementId,
                        principalTable: "ApplicationToFactors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramsParametrToSubjectAreaElements_ProgramsParametrs_Pro~",
                        column: x => x.ProgramsParametrId,
                        principalTable: "ProgramsParametrs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_CreatorId",
                table: "Applications",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationToEstimators_ApplicationId",
                table: "ApplicationToEstimators",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationToEstimators_EstimatorId",
                table: "ApplicationToEstimators",
                column: "EstimatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationToFactors_ApplicationId",
                table: "ApplicationToFactors",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationToFactors_DifficultyLevelId",
                table: "ApplicationToFactors",
                column: "DifficultyLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationToFactors_FactorId",
                table: "ApplicationToFactors",
                column: "FactorId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationToFactors_FactorTypeId",
                table: "ApplicationToFactors",
                column: "FactorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_ParentId",
                table: "Department",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_DifficultyLevelsTypeToFactorTypes_DifficultyLevelId",
                table: "DifficultyLevelsTypeToFactorTypes",
                column: "DifficultyLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_DifficultyLevelsTypeToFactorTypes_FactorTypeId",
                table: "DifficultyLevelsTypeToFactorTypes",
                column: "FactorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Estimators_DepartmentId",
                table: "Estimators",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluatorToEvaluatedFactors_EvaluatedFactorId",
                table: "EvaluatorToEvaluatedFactors",
                column: "EvaluatedFactorId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluatorToEvaluatedFactors_EvaluatorId",
                table: "EvaluatorToEvaluatedFactors",
                column: "EvaluatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_AttributeId",
                table: "Profile",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_EstimatorId",
                table: "Profile",
                column: "EstimatorId");

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
                name: "ApplicationToEstimators");

            migrationBuilder.DropTable(
                name: "DifficultyLevelsTypeToFactorTypes");

            migrationBuilder.DropTable(
                name: "EvaluatorToEvaluatedFactors");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "ProgramsParametrToSubjectAreaElements");

            migrationBuilder.DropTable(
                name: "ApplicationToFactors");

            migrationBuilder.DropTable(
                name: "ProgramsParametrs");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropTable(
                name: "DifficultyLevelsTypes");

            migrationBuilder.DropTable(
                name: "FactorTypes");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "ProgramLanguages");

            migrationBuilder.DropTable(
                name: "Estimators");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
