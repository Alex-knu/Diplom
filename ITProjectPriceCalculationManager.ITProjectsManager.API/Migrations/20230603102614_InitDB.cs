using System;
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SLOC = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Evaluators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DifficultyLevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FactorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FactorTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        principalTable: "Evaluators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EvaluatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        name: "FK_Profile_Estimators_EvaluatorId",
                        column: x => x.EvaluatorId,
                        principalTable: "Evaluators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationToEvaluators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EvaluatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SelfEvaluation = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationToEvaluators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationToEvaluators_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationToEvaluators_Estimators_EvaluatorId",
                        column: x => x.EvaluatorId,
                        principalTable: "Evaluators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationToFactors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DifficultyLevelsTypeToFactorTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProgramLanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EvaluatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EvaluatedFactorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                        principalTable: "Evaluators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProgramsParametrToSubjectAreaElements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProgramsParametrId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectAreaElementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Attributes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("15140cfd-eacc-41f3-aae5-718980da88b9"), "Product novelty for the developer's company(PREC)" },
                    { new Guid("186476d2-772b-4eb1-b140-b0c1a238ae11"), "Level of risk/architecture management (%)(RESL)" },
                    { new Guid("24fbf4f3-aa84-4b17-9d2e-0ef16238a2ba"), "Experience(PREX)" },
                    { new Guid("31f2f6d6-a5fa-4da3-adcf-0a5cc237eb95"), "External output" },
                    { new Guid("33e07ded-1bd4-4e9a-8076-f071ea1a5269"), "Technical support(FCIL)" },
                    { new Guid("4feab03a-7415-4c72-8b3f-6901e014c25e"), "Complexity and reliability(RCPX)" },
                    { new Guid("73a3a716-f447-4057-99ca-1500d438ba58"), "External input" },
                    { new Guid("74b32655-e330-4e74-a1a2-e1e92023f676"), "Cohesion of the development team(TEAM)" },
                    { new Guid("7a0822a4-7012-4738-889b-fafb713f72ea"), "Qualifications(PERS)" },
                    { new Guid("7a540a8b-0198-40d8-9185-2e02ba5eb1ab"), "External request" },
                    { new Guid("9b7d2f14-9ec0-414c-806b-d5e607664031"), "Reuse requested(RUSE)" },
                    { new Guid("b4a2b0b2-35c4-41d4-8ca7-1d2ebd1440e9"), "Development flexibility(FLEX)" },
                    { new Guid("c69edb03-4fb6-4071-bcc5-f158808c69ee"), "Technology maturity maturity process development(PMAT)" },
                    { new Guid("d7c7beea-3351-482b-82e1-8df4573395b9"), "External interface object" },
                    { new Guid("e777b5bf-559d-4194-a711-89ca4ca4a212"), "Internal logical object" },
                    { new Guid("ea5a8d97-0940-4463-b07a-d6a10b6f0d08"), "Schedule restrictions(SCED)" },
                    { new Guid("fe85d6ab-ade6-412f-b2a6-7ca97f4f1da4"), "Complexity of the program environment(PDIF)" }
                });

            migrationBuilder.InsertData(
                table: "DifficultyLevelsTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0c5fd362-b14d-4186-bef9-979ed21b9575"), "Very low" },
                    { new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), "High" },
                    { new Guid("5540d80e-8fae-4afb-a475-b49c1a9c4c2e"), "Medium" },
                    { new Guid("b29fa523-bd56-48be-9adc-cbd23f0af646"), "Normal" },
                    { new Guid("b3b0177d-baf9-4ad6-b1c1-002e1b776a10"), "Super low" },
                    { new Guid("c15c008f-f7f4-4dae-95bb-02a32bb2b8b1"), "Super high" },
                    { new Guid("f5ad4a31-a240-41bd-bffd-245103b88d0f"), "Very high" },
                    { new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), "Low" }
                });

            migrationBuilder.InsertData(
                table: "FactorTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("63715754-cdfb-4320-9c17-72648673cb4b"), "Function" },
                    { new Guid("b03771e5-488a-449f-b886-19c581b63cde"), "Influence factor" },
                    { new Guid("cdd64d87-bb9a-4c17-b809-05c4454e6998"), "Information object" },
                    { new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), "Scale factor" }
                });

            migrationBuilder.InsertData(
                table: "ProgramLanguages",
                columns: new[] { "Id", "Name", "SLOC" },
                values: new object[,]
                {
                    { new Guid("08df04d2-912b-4067-9770-83c0c0ad11f0"), "ABAP (SAP)", 28 },
                    { new Guid("09573e2f-9b64-450a-89b1-a0f037a69f13"), "Brio +", 14 },
                    { new Guid("0a07125f-c029-4ba1-a726-c8c4bfce2f95"), "ASP", 51 },
                    { new Guid("0e60e3a8-695d-4241-81b2-3ac906788a8d"), "JavaScript", 47 },
                    { new Guid("1feb6b40-d349-4f0d-ae3c-31800fa6a413"), "J2EE", 46 },
                    { new Guid("25834df0-a34c-4a4d-9e0c-d8509e3dddd1"), "FoxPro", 36 },
                    { new Guid("52f22f29-82d8-4ce0-8d60-d1b81848a11a"), "Natural", 40 },
                    { new Guid("574899c6-4cca-4a91-92f1-9311a1338289"), "COBOL", 61 },
                    { new Guid("5a715a38-2a05-4b43-8a84-9835bf6e564d"), "JCL", 62 },
                    { new Guid("64f00e6c-edb7-4266-810f-e858873c6aa5"), "Lotus Notes", 23 },
                    { new Guid("6ae7e127-c103-4bba-acba-2447d55d6821"), "Cool:Gen/IEF", 32 },
                    { new Guid("70e51aed-4bc1-4b01-9f9d-2a4729eae4ba"), "Datastage", 71 },
                    { new Guid("763e6d64-87b6-4c34-b594-954cb278db01"), "HTML", 34 },
                    { new Guid("7a08a3fa-4afd-42b1-a35b-fd2f832f272a"), "C", 97 },
                    { new Guid("87022e21-e348-4baf-a2b0-6959a2a01c36"), "Assembler", 119 },
                    { new Guid("8ad8e49e-5dd0-4007-8eec-b165c947da69"), ".NET", 57 },
                    { new Guid("9a95a615-cb0e-4a12-ae5c-4517a6480eba"), "Cognos Impromptu Scripts +", 47 },
                    { new Guid("9cf980b4-a2d9-4b8b-b6a9-689911956783"), "Java", 53 },
                    { new Guid("bc893b63-a04e-448a-9b60-848eecbf39e7"), "Cross System Products (CSP) +", 20 },
                    { new Guid("bec8b82f-f763-44b5-baae-22d46ae93185"), "Oracle", 37 },
                    { new Guid("cb2a99c2-3117-4992-aa69-7094bdb7e6be"), "C++", 50 },
                    { new Guid("e1ce61f7-a7fb-4802-b6f1-aba1d29fb1a6"), "LINC II", 29 },
                    { new Guid("e29b0792-ce69-4159-9468-bcd249a906aa"), "Excel", 209 },
                    { new Guid("e459136a-de0f-4712-b522-9ae61f1804d0"), "C#", 54 },
                    { new Guid("f3a081ef-b2fc-4664-bbf5-26199dc059b1"), "Focus", 43 }
                });

            migrationBuilder.InsertData(
                table: "DifficultyLevelsTypeToFactorTypes",
                columns: new[] { "Id", "DifficultyLevelId", "FactorId", "FactorTypeId", "Value" },
                values: new object[,]
                {
                    { new Guid("00ea34c1-172f-4d5a-a2f1-458322fe4561"), new Guid("c15c008f-f7f4-4dae-95bb-02a32bb2b8b1"), new Guid("c69edb03-4fb6-4071-bcc5-f158808c69ee"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 0.0 },
                    { new Guid("010a62bb-1da1-47af-b61d-90abad7578eb"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("b4a2b0b2-35c4-41d4-8ca7-1d2ebd1440e9"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 2.0299999999999998 },
                    { new Guid("01445c8b-0a85-4545-a66c-0751ef3293d1"), new Guid("b29fa523-bd56-48be-9adc-cbd23f0af646"), new Guid("9b7d2f14-9ec0-414c-806b-d5e607664031"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.0 },
                    { new Guid("06847fef-03c2-43a3-ac5b-2c614ee57cf6"), new Guid("0c5fd362-b14d-4186-bef9-979ed21b9575"), new Guid("4feab03a-7415-4c72-8b3f-6901e014c25e"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.59999999999999998 },
                    { new Guid("077409d6-1c6a-43e9-a241-5612d0db1e31"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("e777b5bf-559d-4194-a711-89ca4ca4a212"), new Guid("cdd64d87-bb9a-4c17-b809-05c4454e6998"), 7.0 },
                    { new Guid("080334d8-5963-4cc0-8136-9191bccda028"), new Guid("c15c008f-f7f4-4dae-95bb-02a32bb2b8b1"), new Guid("7a0822a4-7012-4738-889b-fafb713f72ea"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.5 },
                    { new Guid("08928ccf-e731-4201-963f-38bce1d3054c"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("7a0822a4-7012-4738-889b-fafb713f72ea"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.82999999999999996 },
                    { new Guid("09a3f26e-e28c-4e78-aa1e-b49305996894"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("b4a2b0b2-35c4-41d4-8ca7-1d2ebd1440e9"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 4.0499999999999998 },
                    { new Guid("09c3a9d1-5e20-46e8-9705-0a5f8a027df3"), new Guid("b29fa523-bd56-48be-9adc-cbd23f0af646"), new Guid("74b32655-e330-4e74-a1a2-e1e92023f676"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 3.29 },
                    { new Guid("09f0e38e-7f76-48e8-9f42-543d75ce84dd"), new Guid("b29fa523-bd56-48be-9adc-cbd23f0af646"), new Guid("b4a2b0b2-35c4-41d4-8ca7-1d2ebd1440e9"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 3.04 },
                    { new Guid("0b2d5fe7-d297-4c07-a703-467fafb487d3"), new Guid("c15c008f-f7f4-4dae-95bb-02a32bb2b8b1"), new Guid("ea5a8d97-0940-4463-b07a-d6a10b6f0d08"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.0 },
                    { new Guid("0b95246c-3275-4bee-b6f9-9538b86c5370"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("33e07ded-1bd4-4e9a-8076-f071ea1a5269"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.1000000000000001 },
                    { new Guid("0c5990e1-f1ce-4110-81ec-348a1c913070"), new Guid("f5ad4a31-a240-41bd-bffd-245103b88d0f"), new Guid("ea5a8d97-0940-4463-b07a-d6a10b6f0d08"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.0 },
                    { new Guid("0e414147-fa7f-4858-b6a5-63efb2d17261"), new Guid("b3b0177d-baf9-4ad6-b1c1-002e1b776a10"), new Guid("4feab03a-7415-4c72-8b3f-6901e014c25e"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.48999999999999999 },
                    { new Guid("0f80045c-b619-4d33-9ea4-62c596871929"), new Guid("b29fa523-bd56-48be-9adc-cbd23f0af646"), new Guid("7a0822a4-7012-4738-889b-fafb713f72ea"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.0 },
                    { new Guid("0fb577a4-eabf-43f8-a345-9892c9c3f1b9"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("7a540a8b-0198-40d8-9185-2e02ba5eb1ab"), new Guid("63715754-cdfb-4320-9c17-72648673cb4b"), 3.0 },
                    { new Guid("17b3a936-e4da-4bc9-afa3-e159a25e5265"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("15140cfd-eacc-41f3-aae5-718980da88b9"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 2.48 },
                    { new Guid("187c54ad-b3e7-48e1-bd23-18d6628a4976"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("31f2f6d6-a5fa-4da3-adcf-0a5cc237eb95"), new Guid("63715754-cdfb-4320-9c17-72648673cb4b"), 4.0 },
                    { new Guid("1aa8fc7f-75c2-4f89-87f8-cf1f734df5ee"), new Guid("b29fa523-bd56-48be-9adc-cbd23f0af646"), new Guid("186476d2-772b-4eb1-b140-b0c1a238ae11"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 4.2400000000000002 },
                    { new Guid("1f33720d-dcff-4ecc-be50-e77638689458"), new Guid("c15c008f-f7f4-4dae-95bb-02a32bb2b8b1"), new Guid("33e07ded-1bd4-4e9a-8076-f071ea1a5269"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.62 },
                    { new Guid("22012480-5e1e-42db-80ba-9b181ffa2cc5"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("24fbf4f3-aa84-4b17-9d2e-0ef16238a2ba"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.87 },
                    { new Guid("25ecde11-9402-4c13-90d6-41c78275f6fd"), new Guid("b3b0177d-baf9-4ad6-b1c1-002e1b776a10"), new Guid("9b7d2f14-9ec0-414c-806b-d5e607664031"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.0 },
                    { new Guid("2d31d1ce-49a8-4914-a403-437114976658"), new Guid("f5ad4a31-a240-41bd-bffd-245103b88d0f"), new Guid("74b32655-e330-4e74-a1a2-e1e92023f676"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 1.1000000000000001 },
                    { new Guid("2fa06ea7-a37c-4866-81ae-1a2613659b51"), new Guid("0c5fd362-b14d-4186-bef9-979ed21b9575"), new Guid("b4a2b0b2-35c4-41d4-8ca7-1d2ebd1440e9"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 5.0700000000000003 },
                    { new Guid("2facf71e-b943-4d21-9faf-1434f5ccf8bf"), new Guid("c15c008f-f7f4-4dae-95bb-02a32bb2b8b1"), new Guid("fe85d6ab-ade6-412f-b2a6-7ca97f4f1da4"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 2.6099999999999999 },
                    { new Guid("332d7f7d-c836-44e6-8865-eeaed7cd3831"), new Guid("b29fa523-bd56-48be-9adc-cbd23f0af646"), new Guid("c69edb03-4fb6-4071-bcc5-f158808c69ee"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 4.6799999999999997 },
                    { new Guid("33a2c308-2e6a-45d1-a2ef-b51944433733"), new Guid("f5ad4a31-a240-41bd-bffd-245103b88d0f"), new Guid("9b7d2f14-9ec0-414c-806b-d5e607664031"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.1499999999999999 },
                    { new Guid("344562dd-eefc-4fb8-ab5a-09b49499c106"), new Guid("b29fa523-bd56-48be-9adc-cbd23f0af646"), new Guid("24fbf4f3-aa84-4b17-9d2e-0ef16238a2ba"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.0 },
                    { new Guid("37a116ea-82dc-4853-95d5-5fcd2b06e37e"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("c69edb03-4fb6-4071-bcc5-f158808c69ee"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 3.1200000000000001 },
                    { new Guid("3a997e56-7155-41af-aa31-09cdbec6480c"), new Guid("c15c008f-f7f4-4dae-95bb-02a32bb2b8b1"), new Guid("b4a2b0b2-35c4-41d4-8ca7-1d2ebd1440e9"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 0.0 },
                    { new Guid("3cf106e7-95ff-41a7-ad8f-65726958e65c"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("74b32655-e330-4e74-a1a2-e1e92023f676"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 4.3799999999999999 },
                    { new Guid("3fdab9d5-6656-498c-ac9d-a7549432c663"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("ea5a8d97-0940-4463-b07a-d6a10b6f0d08"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.0 },
                    { new Guid("42d9cce8-9d09-4ce0-bf87-5fab99001744"), new Guid("b29fa523-bd56-48be-9adc-cbd23f0af646"), new Guid("ea5a8d97-0940-4463-b07a-d6a10b6f0d08"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.0 },
                    { new Guid("44c06d2d-56af-4002-bdd2-d194a283a9c8"), new Guid("5540d80e-8fae-4afb-a475-b49c1a9c4c2e"), new Guid("7a540a8b-0198-40d8-9185-2e02ba5eb1ab"), new Guid("63715754-cdfb-4320-9c17-72648673cb4b"), 4.0 },
                    { new Guid("4a51490b-fb60-4186-b9cb-401664cc5359"), new Guid("0c5fd362-b14d-4186-bef9-979ed21b9575"), new Guid("15140cfd-eacc-41f3-aae5-718980da88b9"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 6.2000000000000002 },
                    { new Guid("4c443311-3124-4773-ab18-8d737b09d5b3"), new Guid("5540d80e-8fae-4afb-a475-b49c1a9c4c2e"), new Guid("d7c7beea-3351-482b-82e1-8df4573395b9"), new Guid("cdd64d87-bb9a-4c17-b809-05c4454e6998"), 7.0 },
                    { new Guid("4ea4d568-5b28-4274-a1d8-11c7155aaef0"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("ea5a8d97-0940-4463-b07a-d6a10b6f0d08"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.1399999999999999 },
                    { new Guid("52e0df58-2d52-41d4-bf64-d64e631b12f0"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("c69edb03-4fb6-4071-bcc5-f158808c69ee"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 6.2400000000000002 },
                    { new Guid("531788ef-d484-4e01-85d1-e7029f24eb0a"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("74b32655-e330-4e74-a1a2-e1e92023f676"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 2.1899999999999999 },
                    { new Guid("5e91441b-4c30-4c75-904f-d1f9e50da5e9"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("4feab03a-7415-4c72-8b3f-6901e014c25e"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.3300000000000001 },
                    { new Guid("5ee31be2-ae73-4007-843a-6fb8b039b934"), new Guid("b3b0177d-baf9-4ad6-b1c1-002e1b776a10"), new Guid("24fbf4f3-aa84-4b17-9d2e-0ef16238a2ba"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.5900000000000001 },
                    { new Guid("651f4541-a573-4d2d-b51f-c7f88acb6164"), new Guid("5540d80e-8fae-4afb-a475-b49c1a9c4c2e"), new Guid("e777b5bf-559d-4194-a711-89ca4ca4a212"), new Guid("cdd64d87-bb9a-4c17-b809-05c4454e6998"), 10.0 },
                    { new Guid("66447184-6da6-4024-8647-fb28d8679056"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("fe85d6ab-ade6-412f-b2a6-7ca97f4f1da4"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.29 },
                    { new Guid("6968abd1-ef92-4b58-9ab4-b538af693085"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("e777b5bf-559d-4194-a711-89ca4ca4a212"), new Guid("cdd64d87-bb9a-4c17-b809-05c4454e6998"), 15.0 },
                    { new Guid("6c77d151-9f75-47c2-81e8-1bf845916602"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("73a3a716-f447-4057-99ca-1500d438ba58"), new Guid("63715754-cdfb-4320-9c17-72648673cb4b"), 6.0 },
                    { new Guid("74a0e6ef-956a-4b55-bbc2-134f38797a34"), new Guid("b3b0177d-baf9-4ad6-b1c1-002e1b776a10"), new Guid("7a0822a4-7012-4738-889b-fafb713f72ea"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 2.1200000000000001 },
                    { new Guid("769ddae9-c118-4ea9-a897-15b8866bfbdf"), new Guid("c15c008f-f7f4-4dae-95bb-02a32bb2b8b1"), new Guid("4feab03a-7415-4c72-8b3f-6901e014c25e"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 2.7200000000000002 },
                    { new Guid("76fc4f6c-6e64-4a5b-add8-b26a95658cd2"), new Guid("0c5fd362-b14d-4186-bef9-979ed21b9575"), new Guid("fe85d6ab-ade6-412f-b2a6-7ca97f4f1da4"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.0 },
                    { new Guid("7f56875e-20f8-4e25-9cf1-2a9d5e1b2bf0"), new Guid("f5ad4a31-a240-41bd-bffd-245103b88d0f"), new Guid("7a0822a4-7012-4738-889b-fafb713f72ea"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.63 },
                    { new Guid("88df5f0f-8289-49ae-ad20-016cebd4b645"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("d7c7beea-3351-482b-82e1-8df4573395b9"), new Guid("cdd64d87-bb9a-4c17-b809-05c4454e6998"), 10.0 },
                    { new Guid("8cc17c64-28ae-48c0-bc49-5a93a768aff6"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("33e07ded-1bd4-4e9a-8076-f071ea1a5269"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.87 },
                    { new Guid("8f6a807a-5288-4f09-bbf6-1e40216cd297"), new Guid("c15c008f-f7f4-4dae-95bb-02a32bb2b8b1"), new Guid("186476d2-772b-4eb1-b140-b0c1a238ae11"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 0.0 },
                    { new Guid("92ab395c-604f-4d64-b0ae-120c61629085"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("15140cfd-eacc-41f3-aae5-718980da88b9"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 4.96 },
                    { new Guid("97ce6162-8461-4291-af11-8b522a1545c9"), new Guid("f5ad4a31-a240-41bd-bffd-245103b88d0f"), new Guid("33e07ded-1bd4-4e9a-8076-f071ea1a5269"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.72999999999999998 },
                    { new Guid("998fb1a6-04f7-47c2-ab81-db106f0b7889"), new Guid("0c5fd362-b14d-4186-bef9-979ed21b9575"), new Guid("74b32655-e330-4e74-a1a2-e1e92023f676"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 5.4800000000000004 },
                    { new Guid("9bec3c1e-b3d9-4f1d-839b-a37755e2e0d3"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("9b7d2f14-9ec0-414c-806b-d5e607664031"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.0700000000000001 },
                    { new Guid("9d55abdd-293c-4a93-9e1b-937fee3371de"), new Guid("b29fa523-bd56-48be-9adc-cbd23f0af646"), new Guid("4feab03a-7415-4c72-8b3f-6901e014c25e"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.0 },
                    { new Guid("9e02cb9a-4f14-49d6-9643-37fe8adb84a4"), new Guid("0c5fd362-b14d-4186-bef9-979ed21b9575"), new Guid("9b7d2f14-9ec0-414c-806b-d5e607664031"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.0 },
                    { new Guid("9ec148f0-93b4-41e1-829c-cada31069593"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("24fbf4f3-aa84-4b17-9d2e-0ef16238a2ba"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.1200000000000001 },
                    { new Guid("9f69a437-f98c-439e-a6d5-f0ac0d55e5d1"), new Guid("f5ad4a31-a240-41bd-bffd-245103b88d0f"), new Guid("fe85d6ab-ade6-412f-b2a6-7ca97f4f1da4"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.8100000000000001 },
                    { new Guid("a52c9042-0863-40da-b02f-dd3b5b67726a"), new Guid("f5ad4a31-a240-41bd-bffd-245103b88d0f"), new Guid("b4a2b0b2-35c4-41d4-8ca7-1d2ebd1440e9"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 1.01 },
                    { new Guid("a6cbff94-1d4c-4150-b7ae-e8c0ccde7c40"), new Guid("0c5fd362-b14d-4186-bef9-979ed21b9575"), new Guid("ea5a8d97-0940-4463-b07a-d6a10b6f0d08"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.4299999999999999 },
                    { new Guid("aaa0cb06-3c13-4267-83c9-68e5446b21a1"), new Guid("f5ad4a31-a240-41bd-bffd-245103b88d0f"), new Guid("c69edb03-4fb6-4071-bcc5-f158808c69ee"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 1.5600000000000001 },
                    { new Guid("aea67f51-78f5-466b-a80a-c965ba3f45c7"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("186476d2-772b-4eb1-b140-b0c1a238ae11"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 2.8300000000000001 },
                    { new Guid("aeabd664-245a-441f-94d0-502111b866d8"), new Guid("5540d80e-8fae-4afb-a475-b49c1a9c4c2e"), new Guid("73a3a716-f447-4057-99ca-1500d438ba58"), new Guid("63715754-cdfb-4320-9c17-72648673cb4b"), 4.0 },
                    { new Guid("af7637e2-e950-4e23-b84b-f4e87197d502"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("7a540a8b-0198-40d8-9185-2e02ba5eb1ab"), new Guid("63715754-cdfb-4320-9c17-72648673cb4b"), 6.0 },
                    { new Guid("b131e69e-648c-4126-827e-939feec92e26"), new Guid("b29fa523-bd56-48be-9adc-cbd23f0af646"), new Guid("15140cfd-eacc-41f3-aae5-718980da88b9"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 3.7200000000000002 },
                    { new Guid("b18385d9-e24f-4ba7-8263-8ca596a73e7c"), new Guid("0c5fd362-b14d-4186-bef9-979ed21b9575"), new Guid("24fbf4f3-aa84-4b17-9d2e-0ef16238a2ba"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.3300000000000001 },
                    { new Guid("b244e563-d299-44cb-8ffc-28ecadb13233"), new Guid("c15c008f-f7f4-4dae-95bb-02a32bb2b8b1"), new Guid("15140cfd-eacc-41f3-aae5-718980da88b9"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 0.0 },
                    { new Guid("b2f1d8aa-0f39-42a3-97e3-a235da3ba0f6"), new Guid("0c5fd362-b14d-4186-bef9-979ed21b9575"), new Guid("7a0822a4-7012-4738-889b-fafb713f72ea"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.6200000000000001 },
                    { new Guid("b2f75934-8004-48dd-8f5f-a8bae288efb6"), new Guid("b29fa523-bd56-48be-9adc-cbd23f0af646"), new Guid("33e07ded-1bd4-4e9a-8076-f071ea1a5269"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.0 },
                    { new Guid("b3b7a1e0-0112-422b-a09a-72c7ae2044b7"), new Guid("b3b0177d-baf9-4ad6-b1c1-002e1b776a10"), new Guid("ea5a8d97-0940-4463-b07a-d6a10b6f0d08"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.0 },
                    { new Guid("b717a230-6f6f-4920-8575-3eb54712fe83"), new Guid("c15c008f-f7f4-4dae-95bb-02a32bb2b8b1"), new Guid("24fbf4f3-aa84-4b17-9d2e-0ef16238a2ba"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.62 },
                    { new Guid("bbc9f3e6-5fb3-4da5-81c1-b492e0c8f527"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("73a3a716-f447-4057-99ca-1500d438ba58"), new Guid("63715754-cdfb-4320-9c17-72648673cb4b"), 3.0 },
                    { new Guid("c17d7e59-ad2f-4f61-8b13-011545443617"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("fe85d6ab-ade6-412f-b2a6-7ca97f4f1da4"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.87 },
                    { new Guid("c1adcabb-39e9-4fb9-8059-af933bd9e710"), new Guid("0c5fd362-b14d-4186-bef9-979ed21b9575"), new Guid("c69edb03-4fb6-4071-bcc5-f158808c69ee"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 7.7999999999999998 },
                    { new Guid("c4662ee7-17de-46da-aae3-1c5d217715e0"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("7a0822a4-7012-4738-889b-fafb713f72ea"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.26 },
                    { new Guid("c5f45485-b3e1-477a-9e5b-af92a26c901d"), new Guid("f5ad4a31-a240-41bd-bffd-245103b88d0f"), new Guid("15140cfd-eacc-41f3-aae5-718980da88b9"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 1.24 },
                    { new Guid("c6836473-1462-4378-89e6-30115aa853d8"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("186476d2-772b-4eb1-b140-b0c1a238ae11"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 5.6500000000000004 },
                    { new Guid("cdf53dd1-5e38-4b77-b71e-cd3704b81364"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("4feab03a-7415-4c72-8b3f-6901e014c25e"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.82999999999999996 },
                    { new Guid("d3244fa5-20f9-47b5-be22-3b74cd94ed2b"), new Guid("f5ad4a31-a240-41bd-bffd-245103b88d0f"), new Guid("4feab03a-7415-4c72-8b3f-6901e014c25e"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.97 },
                    { new Guid("d6d3f87c-0314-4ab5-8a8e-e9087d8b1c31"), new Guid("0c5fd362-b14d-4186-bef9-979ed21b9575"), new Guid("186476d2-772b-4eb1-b140-b0c1a238ae11"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 7.0700000000000003 },
                    { new Guid("d8f757ae-878a-4dda-b8f1-c1a2fde5eef2"), new Guid("5540d80e-8fae-4afb-a475-b49c1a9c4c2e"), new Guid("31f2f6d6-a5fa-4da3-adcf-0a5cc237eb95"), new Guid("63715754-cdfb-4320-9c17-72648673cb4b"), 5.0 },
                    { new Guid("db6112be-23bb-46c4-ac1f-22618ad3b1d3"), new Guid("c15c008f-f7f4-4dae-95bb-02a32bb2b8b1"), new Guid("9b7d2f14-9ec0-414c-806b-d5e607664031"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.24 },
                    { new Guid("dde0fdce-ce79-49b1-9b5f-564cd48eb73e"), new Guid("c15c008f-f7f4-4dae-95bb-02a32bb2b8b1"), new Guid("74b32655-e330-4e74-a1a2-e1e92023f676"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 0.0 },
                    { new Guid("df171536-ed65-44a6-8afd-8a8bc67cef5e"), new Guid("b3b0177d-baf9-4ad6-b1c1-002e1b776a10"), new Guid("fe85d6ab-ade6-412f-b2a6-7ca97f4f1da4"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.0 },
                    { new Guid("e0bacc06-d484-4fe2-95aa-2cee39a9d876"), new Guid("f5ad4a31-a240-41bd-bffd-245103b88d0f"), new Guid("24fbf4f3-aa84-4b17-9d2e-0ef16238a2ba"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.70999999999999996 },
                    { new Guid("ea47626b-19b5-446d-b70a-d2e5c010c60a"), new Guid("b3b0177d-baf9-4ad6-b1c1-002e1b776a10"), new Guid("33e07ded-1bd4-4e9a-8076-f071ea1a5269"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.4299999999999999 },
                    { new Guid("ee5775c1-52c0-46e7-95df-e973f314f42b"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("31f2f6d6-a5fa-4da3-adcf-0a5cc237eb95"), new Guid("63715754-cdfb-4320-9c17-72648673cb4b"), 7.0 },
                    { new Guid("f1513fd1-7c0c-4725-9495-11b72bcd40d1"), new Guid("f5ad4a31-a240-41bd-bffd-245103b88d0f"), new Guid("186476d2-772b-4eb1-b140-b0c1a238ae11"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 1.4099999999999999 },
                    { new Guid("f3edb65a-3e63-401d-8db0-8d1dc1096a5e"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("d7c7beea-3351-482b-82e1-8df4573395b9"), new Guid("cdd64d87-bb9a-4c17-b809-05c4454e6998"), 5.0 },
                    { new Guid("f5b54f9b-3976-4de6-a092-3beeb39d1e38"), new Guid("0c5fd362-b14d-4186-bef9-979ed21b9575"), new Guid("33e07ded-1bd4-4e9a-8076-f071ea1a5269"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.3 },
                    { new Guid("fb237587-b7ed-4f7c-93fa-c7f169a407be"), new Guid("b29fa523-bd56-48be-9adc-cbd23f0af646"), new Guid("fe85d6ab-ade6-412f-b2a6-7ca97f4f1da4"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.0 },
                    { new Guid("fd34903c-2514-4955-ae4d-cdf134964d8c"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("9b7d2f14-9ec0-414c-806b-d5e607664031"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.94999999999999996 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_CreatorId",
                table: "Applications",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationToEvaluators_ApplicationId",
                table: "ApplicationToEvaluators",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationToEvaluators_EvaluatorId",
                table: "ApplicationToEvaluators",
                column: "EvaluatorId");

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
                table: "Evaluators",
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
                name: "IX_Profile_EvaluatorId",
                table: "Profile",
                column: "EvaluatorId");

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
                name: "ApplicationToEvaluators");

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
                name: "Evaluators");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
