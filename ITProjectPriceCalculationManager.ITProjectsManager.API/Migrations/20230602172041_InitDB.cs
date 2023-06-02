using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DifficultyLevelsTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FactorTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactorTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgramLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SLOC = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estimators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DifficultyLevelId = table.Column<int>(type: "int", nullable: false),
                    FactorId = table.Column<int>(type: "int", nullable: false),
                    FactorTypeId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DifficultyLevelsTypeToFactorTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DifficultyLevelsTypeToFactorTypes_Attributes_FactorId",
                        column: x => x.FactorId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DifficultyLevelsTypeToFactorTypes_DifficultyLevelsTypes_DifficultyLevelId",
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Profit = table.Column<double>(type: "float", nullable: false),
                    Overhead = table.Column<double>(type: "float", nullable: false),
                    SocialInsurance = table.Column<double>(type: "float", nullable: false),
                    AverageCostLabor = table.Column<double>(type: "float", nullable: false),
                    AverageMonthlyRateWorkingHours = table.Column<double>(type: "float", nullable: false),
                    ConfidenceArea = table.Column<double>(type: "float", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeId = table.Column<int>(type: "int", nullable: false),
                    EstimatorId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    EstimatorId = table.Column<int>(type: "int", nullable: false),
                    SelfEvaluation = table.Column<double>(type: "float", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    DifficultyLevelsTypeToFactorTypeId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
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
                        name: "FK_ApplicationToFactors_DifficultyLevelsTypeToFactorTypes_DifficultyLevelsTypeToFactorTypeId",
                        column: x => x.DifficultyLevelsTypeToFactorTypeId,
                        principalTable: "DifficultyLevelsTypeToFactorTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramsParametrs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramLanguageId = table.Column<int>(type: "int", nullable: false),
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvaluatorId = table.Column<int>(type: "int", nullable: false),
                    EvaluatedFactorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluatorToEvaluatedFactors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluatorToEvaluatedFactors_ApplicationToFactors_EvaluatedFactorId",
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramsParametrId = table.Column<int>(type: "int", nullable: false),
                    SubjectAreaElementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramsParametrToSubjectAreaElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramsParametrToSubjectAreaElements_ApplicationToFactors_SubjectAreaElementId",
                        column: x => x.SubjectAreaElementId,
                        principalTable: "ApplicationToFactors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramsParametrToSubjectAreaElements_ProgramsParametrs_ProgramsParametrId",
                        column: x => x.ProgramsParametrId,
                        principalTable: "ProgramsParametrs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Attributes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Qualifications(PERS)" },
                    { 2, "Experience(PREX)" },
                    { 3, "Technical support(FCIL)" },
                    { 4, "Schedule restrictions(SCED)" },
                    { 5, "Complexity of the program environment(PDIF)" },
                    { 6, "Complexity and reliability(RCPX)" },
                    { 7, "Reuse requested(RUSE)" },
                    { 8, "Product novelty for the developer's company(PREC)" },
                    { 9, "Development flexibility(FLEX)" },
                    { 10, "Level of risk/architecture management (%)(RESL)" },
                    { 11, "Cohesion of the development team(TEAM)" },
                    { 12, "Technology maturity maturity process development(PMAT)" },
                    { 13, "Internal logical object" },
                    { 14, "External interface object" },
                    { 15, "External input" },
                    { 16, "External output" },
                    { 17, "External request" }
                });

            migrationBuilder.InsertData(
                table: "DifficultyLevelsTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Super low" },
                    { 2, "Very low" },
                    { 3, "Low" },
                    { 4, "Normal" },
                    { 5, "Medium" },
                    { 6, "High" },
                    { 7, "Very high" },
                    { 8, "Super high" }
                });

            migrationBuilder.InsertData(
                table: "FactorTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Influence factor" },
                    { 2, "Scale factor" },
                    { 3, "Information object" },
                    { 4, "Function" }
                });

            migrationBuilder.InsertData(
                table: "ProgramLanguages",
                columns: new[] { "Id", "Name", "SLOC" },
                values: new object[,]
                {
                    { 1, "ABAP (SAP)", 28 },
                    { 2, "ASP", 51 },
                    { 3, "Assembler", 119 },
                    { 4, "Brio +", 14 },
                    { 5, "C", 97 },
                    { 6, "C++", 50 },
                    { 7, "C#", 54 },
                    { 8, "COBOL", 61 },
                    { 9, "Cognos Impromptu Scripts +", 47 },
                    { 10, "Cross System Products (CSP) +", 20 },
                    { 11, "Cool:Gen/IEF", 32 },
                    { 12, "Datastage", 71 },
                    { 13, "Excel", 209 },
                    { 14, "Focus", 43 },
                    { 15, "FoxPro", 36 },
                    { 16, "HTML", 34 },
                    { 17, "J2EE", 46 },
                    { 18, "Java", 53 },
                    { 19, "JavaScript", 47 },
                    { 20, "JCL", 62 },
                    { 21, "LINC II", 29 },
                    { 22, "Lotus Notes", 23 },
                    { 23, "Natural", 40 },
                    { 24, ".NET", 57 },
                    { 25, "Oracle", 37 }
                });

            migrationBuilder.InsertData(
                table: "DifficultyLevelsTypeToFactorTypes",
                columns: new[] { "Id", "DifficultyLevelId", "FactorId", "FactorTypeId", "Value" },
                values: new object[,]
                {
                    { 1, 3, 13, 3, 7.0 },
                    { 2, 5, 13, 3, 10.0 },
                    { 3, 6, 13, 3, 15.0 },
                    { 4, 3, 14, 3, 5.0 },
                    { 5, 5, 14, 3, 7.0 },
                    { 6, 6, 14, 3, 10.0 },
                    { 7, 1, 1, 1, 2.1200000000000001 },
                    { 8, 2, 1, 1, 1.6200000000000001 },
                    { 9, 3, 1, 1, 1.26 },
                    { 10, 4, 1, 1, 1.0 },
                    { 11, 6, 1, 1, 0.82999999999999996 },
                    { 12, 7, 1, 1, 0.63 },
                    { 13, 8, 1, 1, 0.5 },
                    { 14, 1, 2, 1, 1.5900000000000001 },
                    { 15, 2, 2, 1, 1.3300000000000001 },
                    { 16, 3, 2, 1, 1.1200000000000001 },
                    { 17, 4, 2, 1, 1.0 },
                    { 18, 6, 2, 1, 0.87 },
                    { 19, 7, 2, 1, 0.70999999999999996 },
                    { 20, 8, 2, 1, 0.62 },
                    { 21, 1, 3, 1, 1.4299999999999999 },
                    { 22, 2, 3, 1, 1.3 },
                    { 23, 3, 3, 1, 1.1000000000000001 },
                    { 24, 4, 3, 1, 1.0 },
                    { 25, 6, 3, 1, 0.87 },
                    { 26, 7, 3, 1, 0.72999999999999998 },
                    { 27, 8, 3, 1, 0.62 },
                    { 28, 1, 4, 1, 0.0 },
                    { 29, 2, 4, 1, 1.4299999999999999 },
                    { 30, 3, 4, 1, 1.1399999999999999 },
                    { 31, 4, 4, 1, 1.0 },
                    { 32, 6, 4, 1, 1.0 },
                    { 33, 7, 4, 1, 1.0 },
                    { 34, 8, 4, 1, 0.0 },
                    { 35, 1, 5, 1, 0.0 },
                    { 36, 2, 5, 1, 0.0 },
                    { 37, 3, 5, 1, 0.87 },
                    { 38, 4, 5, 1, 1.0 },
                    { 39, 6, 5, 1, 1.29 },
                    { 40, 7, 5, 1, 1.8100000000000001 },
                    { 41, 8, 5, 1, 2.6099999999999999 },
                    { 42, 1, 6, 1, 0.48999999999999999 },
                    { 43, 2, 6, 1, 0.59999999999999998 },
                    { 44, 3, 6, 1, 0.82999999999999996 },
                    { 45, 4, 6, 1, 1.0 },
                    { 46, 6, 6, 1, 1.3300000000000001 },
                    { 47, 7, 6, 1, 1.97 },
                    { 48, 8, 6, 1, 2.7200000000000002 },
                    { 49, 1, 7, 1, 0.0 },
                    { 50, 2, 7, 1, 0.0 },
                    { 51, 3, 7, 1, 0.94999999999999996 },
                    { 52, 4, 7, 1, 1.0 },
                    { 53, 6, 7, 1, 1.0700000000000001 },
                    { 54, 7, 7, 1, 1.1499999999999999 },
                    { 55, 8, 7, 1, 1.24 },
                    { 56, 2, 8, 2, 6.2000000000000002 },
                    { 57, 3, 8, 2, 4.96 },
                    { 58, 4, 8, 2, 3.7200000000000002 },
                    { 59, 6, 8, 2, 2.48 },
                    { 60, 7, 8, 2, 1.24 },
                    { 61, 8, 8, 2, 0.0 },
                    { 62, 2, 9, 2, 5.0700000000000003 },
                    { 63, 3, 9, 2, 4.0499999999999998 },
                    { 64, 4, 9, 2, 3.04 },
                    { 65, 6, 9, 2, 2.0299999999999998 },
                    { 66, 7, 9, 2, 1.01 },
                    { 67, 8, 9, 2, 0.0 },
                    { 68, 2, 10, 2, 7.0700000000000003 },
                    { 69, 3, 10, 2, 5.6500000000000004 },
                    { 70, 4, 10, 2, 4.2400000000000002 },
                    { 71, 6, 10, 2, 2.8300000000000001 },
                    { 72, 7, 10, 2, 1.4099999999999999 },
                    { 73, 8, 10, 2, 0.0 },
                    { 74, 2, 11, 2, 5.4800000000000004 },
                    { 75, 3, 11, 2, 4.3799999999999999 },
                    { 76, 4, 11, 2, 3.29 },
                    { 77, 6, 11, 2, 2.1899999999999999 },
                    { 78, 7, 11, 2, 1.1000000000000001 },
                    { 79, 8, 11, 2, 0.0 },
                    { 80, 2, 12, 2, 7.7999999999999998 },
                    { 81, 3, 12, 2, 6.2400000000000002 },
                    { 82, 4, 12, 2, 4.6799999999999997 },
                    { 83, 6, 12, 2, 3.1200000000000001 },
                    { 84, 7, 12, 2, 1.5600000000000001 },
                    { 85, 8, 12, 2, 0.0 },
                    { 86, 3, 15, 4, 3.0 },
                    { 87, 5, 15, 4, 4.0 },
                    { 88, 6, 15, 4, 6.0 },
                    { 89, 3, 16, 4, 4.0 },
                    { 90, 5, 16, 4, 5.0 },
                    { 91, 6, 16, 4, 7.0 },
                    { 92, 3, 17, 4, 3.0 },
                    { 93, 3, 17, 4, 4.0 },
                    { 94, 3, 17, 4, 6.0 }
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
                name: "IX_ApplicationToFactors_DifficultyLevelsTypeToFactorTypeId",
                table: "ApplicationToFactors",
                column: "DifficultyLevelsTypeToFactorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_ParentId",
                table: "Department",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_DifficultyLevelsTypeToFactorTypes_DifficultyLevelId",
                table: "DifficultyLevelsTypeToFactorTypes",
                column: "DifficultyLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_DifficultyLevelsTypeToFactorTypes_FactorId",
                table: "DifficultyLevelsTypeToFactorTypes",
                column: "FactorId");

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
                name: "DifficultyLevelsTypeToFactorTypes");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "ProgramLanguages");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropTable(
                name: "DifficultyLevelsTypes");

            migrationBuilder.DropTable(
                name: "FactorTypes");

            migrationBuilder.DropTable(
                name: "Estimators");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
