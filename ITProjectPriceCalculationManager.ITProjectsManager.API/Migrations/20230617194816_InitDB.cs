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
                name: "ApplicationForEvaluations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Profit = table.Column<double>(type: "float", nullable: false),
                    Overhead = table.Column<double>(type: "float", nullable: false),
                    SocialInsurance = table.Column<double>(type: "float", nullable: false),
                    AverageCostLabor = table.Column<double>(type: "float", nullable: false),
                    AverageMonthlyRateWorkingHours = table.Column<double>(type: "float", nullable: false),
                    ConfidenceArea = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationForEvaluations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationStatuses", x => x.Id);
                });

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
                name: "EvaluationAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FactorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FactorTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationAttributes", x => x.Id);
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
                    table.PrimaryKey("PK_Evaluators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluators_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DifficultyLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EvaluationAttributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DifficultyLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DifficultyLevels_EvaluationAttributes_EvaluationAttributeId",
                        column: x => x.EvaluationAttributeId,
                        principalTable: "EvaluationAttributes",
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
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Profit = table.Column<double>(type: "float", nullable: false),
                    Overhead = table.Column<double>(type: "float", nullable: false),
                    SocialInsurance = table.Column<double>(type: "float", nullable: false),
                    AverageCostLabor = table.Column<double>(type: "float", nullable: false),
                    AverageMonthlyRateWorkingHours = table.Column<double>(type: "float", nullable: false),
                    ConfidenceArea = table.Column<double>(type: "float", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_ApplicationStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ApplicationStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applications_Evaluators_CreatorId",
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
                        name: "FK_Profile_Evaluators_EvaluatorId",
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
                        name: "FK_ApplicationToEvaluators_Evaluators_EvaluatorId",
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
                    Value = table.Column<double>(type: "float", nullable: true)
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
                        name: "FK_EvaluatorToEvaluatedFactors_Evaluators_EvaluatorId",
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
                table: "ApplicationStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4706d234-e64d-4ab2-bed0-6086e10c3325"), "Нова" },
                    { new Guid("56533c08-2c5b-4bba-8dc2-9efe0fb3dc66"), "Оцінено" },
                    { new Guid("9806f24d-89d7-42f5-80b4-d39ac7798949"), "На доопрацюванні" },
                    { new Guid("c4a6971d-a0de-4d6d-97fe-67db465e330f"), "На оцінюванні" }
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
                    { new Guid("00240fb2-4f29-431f-93b9-adfa31ceaaca"), "Cross System Products (CSP) +", 20 },
                    { new Guid("02f4ccdb-9fdb-4c65-87a8-3567d84a1781"), "J2EE", 46 },
                    { new Guid("10e69836-68a8-41cb-96c8-4ca6bc1190d1"), "Excel", 209 },
                    { new Guid("2229a77c-bdb4-4737-aaab-a5b456f74126"), "Java", 53 },
                    { new Guid("22a1ad68-c278-4236-861b-0a256ca2a0b3"), "HTML", 34 },
                    { new Guid("32c19d74-6993-4d0e-8647-cdf75541e728"), "Cognos Impromptu Scripts +", 47 },
                    { new Guid("34cb9cbc-564c-4494-bfda-941473f35341"), ".NET", 57 },
                    { new Guid("491c0205-a64e-46d1-8be0-25fabe8b6ae6"), "C", 97 },
                    { new Guid("4e943d03-e4be-4ed2-b492-421b6c7b1c92"), "COBOL", 61 },
                    { new Guid("676bd39b-61fa-4718-af90-e2378851acdd"), "Datastage", 71 },
                    { new Guid("736c315e-ec2b-4abf-8c4b-7f202939dced"), "Focus", 43 },
                    { new Guid("794b2ac4-3310-4264-a367-d1e665a55458"), "ABAP (SAP)", 28 },
                    { new Guid("8a889366-5efc-4bd4-be67-1373938692eb"), "LINC II", 29 },
                    { new Guid("98254d9f-f5ea-46f5-9278-fc77c8ff2b5a"), "JCL", 62 },
                    { new Guid("9f9752c2-18db-4b97-9d61-752b20aabb0c"), "Lotus Notes", 23 },
                    { new Guid("a879c89b-11e3-4ae1-8b2a-eae6a126557c"), "Brio +", 14 },
                    { new Guid("aef38b0a-456c-455b-acca-fe7600ec8de8"), "C#", 54 },
                    { new Guid("b8c17601-7672-4b36-b4d5-975573edcaba"), "Cool:Gen/IEF", 32 },
                    { new Guid("c16181c5-3493-4223-8267-9d4d71b50eed"), "Oracle", 37 },
                    { new Guid("c26246c3-caad-4d34-a42a-f6517cf45ef6"), "ASP", 51 },
                    { new Guid("c77c165f-3c3a-4e56-848f-0afe15af2315"), "FoxPro", 36 },
                    { new Guid("d1627cf2-b9ad-46ac-9e84-93438f4ed0d1"), "Natural", 40 },
                    { new Guid("e3810495-b6ab-42af-87a6-9ba5f7393cd5"), "Assembler", 119 },
                    { new Guid("ee1f313e-9603-4ebe-a3bd-e0da9c639a7d"), "JavaScript", 47 },
                    { new Guid("f3cd8a9f-dc66-46a4-b41b-f57c1d82a1ce"), "C++", 50 }
                });

            migrationBuilder.InsertData(
                table: "DifficultyLevelsTypeToFactorTypes",
                columns: new[] { "Id", "DifficultyLevelId", "FactorId", "FactorTypeId", "Value" },
                values: new object[,]
                {
                    { new Guid("05f60293-444f-44c0-9ed4-6d481f565f22"), new Guid("0c5fd362-b14d-4186-bef9-979ed21b9575"), new Guid("15140cfd-eacc-41f3-aae5-718980da88b9"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 6.2000000000000002 },
                    { new Guid("08386350-d2bb-48d8-894a-9f8f25fe00de"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("31f2f6d6-a5fa-4da3-adcf-0a5cc237eb95"), new Guid("63715754-cdfb-4320-9c17-72648673cb4b"), 4.0 },
                    { new Guid("089ffa0a-9691-4038-89f2-d0febb22058a"), new Guid("5540d80e-8fae-4afb-a475-b49c1a9c4c2e"), new Guid("31f2f6d6-a5fa-4da3-adcf-0a5cc237eb95"), new Guid("63715754-cdfb-4320-9c17-72648673cb4b"), 5.0 },
                    { new Guid("0ae2eaa5-e327-4425-95f1-822ae8ea01a6"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("4feab03a-7415-4c72-8b3f-6901e014c25e"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.82999999999999996 },
                    { new Guid("0f4e8272-fe20-4665-b1c7-40358219826d"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("b4a2b0b2-35c4-41d4-8ca7-1d2ebd1440e9"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 2.0299999999999998 },
                    { new Guid("101f9ac2-462a-4e73-bff3-d2de9bd39c26"), new Guid("b29fa523-bd56-48be-9adc-cbd23f0af646"), new Guid("c69edb03-4fb6-4071-bcc5-f158808c69ee"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 4.6799999999999997 },
                    { new Guid("158ebafb-d831-408c-a7db-989c3674a5d7"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("c69edb03-4fb6-4071-bcc5-f158808c69ee"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 6.2400000000000002 },
                    { new Guid("1c1f5991-cba7-4247-b338-5640d3237568"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("33e07ded-1bd4-4e9a-8076-f071ea1a5269"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.87 },
                    { new Guid("218cc659-82f0-4843-94f0-702a5dfaeee2"), new Guid("f5ad4a31-a240-41bd-bffd-245103b88d0f"), new Guid("b4a2b0b2-35c4-41d4-8ca7-1d2ebd1440e9"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 1.01 },
                    { new Guid("226f4f9f-8563-437d-859b-b0bdf72e74d1"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("d7c7beea-3351-482b-82e1-8df4573395b9"), new Guid("cdd64d87-bb9a-4c17-b809-05c4454e6998"), 5.0 },
                    { new Guid("2474fdf5-1c38-4d46-a2e4-6fef3655d533"), new Guid("b29fa523-bd56-48be-9adc-cbd23f0af646"), new Guid("fe85d6ab-ade6-412f-b2a6-7ca97f4f1da4"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.0 },
                    { new Guid("26bb242d-fe62-4865-9b7e-74ecd8c85eb1"), new Guid("c15c008f-f7f4-4dae-95bb-02a32bb2b8b1"), new Guid("b4a2b0b2-35c4-41d4-8ca7-1d2ebd1440e9"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 0.0 },
                    { new Guid("2a9240e9-b392-4a31-8f55-fb1f3e1e7399"), new Guid("0c5fd362-b14d-4186-bef9-979ed21b9575"), new Guid("33e07ded-1bd4-4e9a-8076-f071ea1a5269"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.3 },
                    { new Guid("2f46aca0-6752-4352-9b57-2fbdacb7d576"), new Guid("0c5fd362-b14d-4186-bef9-979ed21b9575"), new Guid("9b7d2f14-9ec0-414c-806b-d5e607664031"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.0 },
                    { new Guid("2fef6711-824d-4a7e-bc76-df7951b3d211"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("74b32655-e330-4e74-a1a2-e1e92023f676"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 4.3799999999999999 },
                    { new Guid("3013382f-daa7-4333-a4b5-e09a92158212"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("4feab03a-7415-4c72-8b3f-6901e014c25e"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.3300000000000001 },
                    { new Guid("31712da9-288f-4a6d-9c08-f446c130986c"), new Guid("c15c008f-f7f4-4dae-95bb-02a32bb2b8b1"), new Guid("33e07ded-1bd4-4e9a-8076-f071ea1a5269"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.62 },
                    { new Guid("393ef14d-5612-4b29-979c-29b0e273bd1e"), new Guid("0c5fd362-b14d-4186-bef9-979ed21b9575"), new Guid("ea5a8d97-0940-4463-b07a-d6a10b6f0d08"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.4299999999999999 },
                    { new Guid("43cced97-4cb6-413b-ad18-9241389d63b3"), new Guid("c15c008f-f7f4-4dae-95bb-02a32bb2b8b1"), new Guid("ea5a8d97-0940-4463-b07a-d6a10b6f0d08"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.0 },
                    { new Guid("44666184-1e47-4bcd-bbe3-60bfbfec5c9e"), new Guid("c15c008f-f7f4-4dae-95bb-02a32bb2b8b1"), new Guid("186476d2-772b-4eb1-b140-b0c1a238ae11"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 0.0 },
                    { new Guid("47464ce2-4daa-4d14-9e2d-285c254d0c27"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("24fbf4f3-aa84-4b17-9d2e-0ef16238a2ba"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.87 },
                    { new Guid("47eab601-4c65-405a-91b5-21bcc1a5acec"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("73a3a716-f447-4057-99ca-1500d438ba58"), new Guid("63715754-cdfb-4320-9c17-72648673cb4b"), 6.0 },
                    { new Guid("48ef82ae-e8cc-4eb5-8aaf-8283296e1d00"), new Guid("f5ad4a31-a240-41bd-bffd-245103b88d0f"), new Guid("fe85d6ab-ade6-412f-b2a6-7ca97f4f1da4"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.8100000000000001 },
                    { new Guid("49543d41-1ce2-4d6c-9c7e-af9ffbdfae53"), new Guid("b29fa523-bd56-48be-9adc-cbd23f0af646"), new Guid("33e07ded-1bd4-4e9a-8076-f071ea1a5269"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.0 },
                    { new Guid("4a070749-70e4-4099-867c-0ce887e974b2"), new Guid("f5ad4a31-a240-41bd-bffd-245103b88d0f"), new Guid("9b7d2f14-9ec0-414c-806b-d5e607664031"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.1499999999999999 },
                    { new Guid("4a336b4d-61d9-48a1-970c-a0e69ac48fa7"), new Guid("c15c008f-f7f4-4dae-95bb-02a32bb2b8b1"), new Guid("7a0822a4-7012-4738-889b-fafb713f72ea"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.5 },
                    { new Guid("4d0492d2-12c3-4adf-b35e-c3ba949092af"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("ea5a8d97-0940-4463-b07a-d6a10b6f0d08"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.0 },
                    { new Guid("4d413d42-df92-483a-a769-3c70e6538bbd"), new Guid("b3b0177d-baf9-4ad6-b1c1-002e1b776a10"), new Guid("7a0822a4-7012-4738-889b-fafb713f72ea"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 2.1200000000000001 },
                    { new Guid("502fe0cf-563e-4d8e-b65e-2bd3415f777a"), new Guid("b3b0177d-baf9-4ad6-b1c1-002e1b776a10"), new Guid("33e07ded-1bd4-4e9a-8076-f071ea1a5269"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.4299999999999999 },
                    { new Guid("50e9950f-e449-425b-b2c4-00416bfd7002"), new Guid("c15c008f-f7f4-4dae-95bb-02a32bb2b8b1"), new Guid("74b32655-e330-4e74-a1a2-e1e92023f676"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 0.0 },
                    { new Guid("5602f52e-029d-41ca-84a4-240f70edf8c5"), new Guid("b29fa523-bd56-48be-9adc-cbd23f0af646"), new Guid("74b32655-e330-4e74-a1a2-e1e92023f676"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 3.29 },
                    { new Guid("58b98824-d6af-4fea-92fe-3292cc18a7b1"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("9b7d2f14-9ec0-414c-806b-d5e607664031"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.94999999999999996 },
                    { new Guid("5b20f57c-c7f0-4d2e-aa98-e8a250cd1e8f"), new Guid("b3b0177d-baf9-4ad6-b1c1-002e1b776a10"), new Guid("fe85d6ab-ade6-412f-b2a6-7ca97f4f1da4"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.0 },
                    { new Guid("5d4848bd-c214-4159-b279-cf2eebee3fce"), new Guid("b29fa523-bd56-48be-9adc-cbd23f0af646"), new Guid("9b7d2f14-9ec0-414c-806b-d5e607664031"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.0 },
                    { new Guid("5e1378ea-d04f-47af-a161-b3aa5232c713"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("b4a2b0b2-35c4-41d4-8ca7-1d2ebd1440e9"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 4.0499999999999998 },
                    { new Guid("5f200051-a4b6-45b9-b6ce-9ba41351849b"), new Guid("0c5fd362-b14d-4186-bef9-979ed21b9575"), new Guid("24fbf4f3-aa84-4b17-9d2e-0ef16238a2ba"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.3300000000000001 },
                    { new Guid("5fda3d4e-6657-4cb8-81bd-22c9b60f5a32"), new Guid("c15c008f-f7f4-4dae-95bb-02a32bb2b8b1"), new Guid("9b7d2f14-9ec0-414c-806b-d5e607664031"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.24 },
                    { new Guid("61df3738-c7c6-4dd5-95e3-aac57b78062a"), new Guid("5540d80e-8fae-4afb-a475-b49c1a9c4c2e"), new Guid("d7c7beea-3351-482b-82e1-8df4573395b9"), new Guid("cdd64d87-bb9a-4c17-b809-05c4454e6998"), 7.0 },
                    { new Guid("63181747-3e61-4cdf-bd83-438f44f953c9"), new Guid("f5ad4a31-a240-41bd-bffd-245103b88d0f"), new Guid("ea5a8d97-0940-4463-b07a-d6a10b6f0d08"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.0 },
                    { new Guid("66744342-2820-4fbf-9f97-917f3099647b"), new Guid("5540d80e-8fae-4afb-a475-b49c1a9c4c2e"), new Guid("7a540a8b-0198-40d8-9185-2e02ba5eb1ab"), new Guid("63715754-cdfb-4320-9c17-72648673cb4b"), 4.0 },
                    { new Guid("7908d221-07c3-4716-bbf6-6539503aec71"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("9b7d2f14-9ec0-414c-806b-d5e607664031"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.0700000000000001 },
                    { new Guid("79e53275-6e20-41a9-ae04-1f7cec1ec9e1"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("e777b5bf-559d-4194-a711-89ca4ca4a212"), new Guid("cdd64d87-bb9a-4c17-b809-05c4454e6998"), 7.0 },
                    { new Guid("7b27efd0-fee3-4689-98cd-95c444fb04d5"), new Guid("f5ad4a31-a240-41bd-bffd-245103b88d0f"), new Guid("7a0822a4-7012-4738-889b-fafb713f72ea"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.63 },
                    { new Guid("7bb09544-59ff-4733-a023-bf5d952e01ee"), new Guid("0c5fd362-b14d-4186-bef9-979ed21b9575"), new Guid("4feab03a-7415-4c72-8b3f-6901e014c25e"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.59999999999999998 },
                    { new Guid("7c53bf48-3633-4727-84f3-d16765c20dce"), new Guid("b3b0177d-baf9-4ad6-b1c1-002e1b776a10"), new Guid("9b7d2f14-9ec0-414c-806b-d5e607664031"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.0 },
                    { new Guid("7e608ff2-0cbf-41bb-b0a1-f684d07536d8"), new Guid("f5ad4a31-a240-41bd-bffd-245103b88d0f"), new Guid("33e07ded-1bd4-4e9a-8076-f071ea1a5269"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.72999999999999998 },
                    { new Guid("7f72fb34-c1ea-4df6-9777-09cc50f20737"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("186476d2-772b-4eb1-b140-b0c1a238ae11"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 5.6500000000000004 },
                    { new Guid("80835d99-cec6-454c-b490-52e484f094cb"), new Guid("0c5fd362-b14d-4186-bef9-979ed21b9575"), new Guid("b4a2b0b2-35c4-41d4-8ca7-1d2ebd1440e9"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 5.0700000000000003 },
                    { new Guid("80ba2fb4-b9f1-4888-8469-8c4dbdc9ac33"), new Guid("b29fa523-bd56-48be-9adc-cbd23f0af646"), new Guid("15140cfd-eacc-41f3-aae5-718980da88b9"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 3.7200000000000002 },
                    { new Guid("83591b36-ccd6-451f-a908-4a241012e96b"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("7a0822a4-7012-4738-889b-fafb713f72ea"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.26 },
                    { new Guid("8c955d7f-dcd0-474a-85d7-d77b2c3f39eb"), new Guid("b29fa523-bd56-48be-9adc-cbd23f0af646"), new Guid("24fbf4f3-aa84-4b17-9d2e-0ef16238a2ba"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.0 },
                    { new Guid("8e90a730-a896-41d2-96d9-08c1d47e74c0"), new Guid("0c5fd362-b14d-4186-bef9-979ed21b9575"), new Guid("fe85d6ab-ade6-412f-b2a6-7ca97f4f1da4"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.0 },
                    { new Guid("9107c797-fa19-48e0-ae64-300c78b62b84"), new Guid("b29fa523-bd56-48be-9adc-cbd23f0af646"), new Guid("4feab03a-7415-4c72-8b3f-6901e014c25e"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.0 },
                    { new Guid("929ee2d0-b285-4c30-bf89-e371058ea6a8"), new Guid("b29fa523-bd56-48be-9adc-cbd23f0af646"), new Guid("186476d2-772b-4eb1-b140-b0c1a238ae11"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 4.2400000000000002 },
                    { new Guid("9518e8b5-c821-4b75-b7dc-8aee1b39ed76"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("fe85d6ab-ade6-412f-b2a6-7ca97f4f1da4"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.29 },
                    { new Guid("98ef60ad-14da-422a-b24c-9f3eb6d58648"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("e777b5bf-559d-4194-a711-89ca4ca4a212"), new Guid("cdd64d87-bb9a-4c17-b809-05c4454e6998"), 15.0 },
                    { new Guid("99555d3a-6b6d-42be-afe2-17ffae0547c4"), new Guid("b3b0177d-baf9-4ad6-b1c1-002e1b776a10"), new Guid("ea5a8d97-0940-4463-b07a-d6a10b6f0d08"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.0 },
                    { new Guid("a0229597-864b-49e7-ab48-e8bacd811ebf"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("c69edb03-4fb6-4071-bcc5-f158808c69ee"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 3.1200000000000001 },
                    { new Guid("a17667db-caaf-4644-986a-c7909be4295f"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("33e07ded-1bd4-4e9a-8076-f071ea1a5269"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.1000000000000001 },
                    { new Guid("a1b726ed-b26e-4f23-8132-eee2438f2969"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("186476d2-772b-4eb1-b140-b0c1a238ae11"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 2.8300000000000001 },
                    { new Guid("a9596334-4666-4b29-a6bd-4d622ae5397d"), new Guid("b3b0177d-baf9-4ad6-b1c1-002e1b776a10"), new Guid("4feab03a-7415-4c72-8b3f-6901e014c25e"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.48999999999999999 },
                    { new Guid("aa4b9e0c-0f9c-42d7-bca1-db48d90af5fc"), new Guid("f5ad4a31-a240-41bd-bffd-245103b88d0f"), new Guid("24fbf4f3-aa84-4b17-9d2e-0ef16238a2ba"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.70999999999999996 },
                    { new Guid("ad158205-ff97-42a2-9abc-0040a8560c7e"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("7a0822a4-7012-4738-889b-fafb713f72ea"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.82999999999999996 },
                    { new Guid("ad714742-d8bf-4a86-839e-9fd98822ba87"), new Guid("5540d80e-8fae-4afb-a475-b49c1a9c4c2e"), new Guid("e777b5bf-559d-4194-a711-89ca4ca4a212"), new Guid("cdd64d87-bb9a-4c17-b809-05c4454e6998"), 10.0 },
                    { new Guid("ae79da70-8847-4539-abb8-5cdf7d94772f"), new Guid("f5ad4a31-a240-41bd-bffd-245103b88d0f"), new Guid("4feab03a-7415-4c72-8b3f-6901e014c25e"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.97 },
                    { new Guid("aea4daa0-2f03-4ef1-8ef5-787e676924e4"), new Guid("c15c008f-f7f4-4dae-95bb-02a32bb2b8b1"), new Guid("24fbf4f3-aa84-4b17-9d2e-0ef16238a2ba"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.62 },
                    { new Guid("afb9e99d-f300-4ae4-b2d7-c3099a660f4d"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("24fbf4f3-aa84-4b17-9d2e-0ef16238a2ba"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.1200000000000001 },
                    { new Guid("b27a1cf4-8043-4a26-a149-4bbac0efa9d7"), new Guid("f5ad4a31-a240-41bd-bffd-245103b88d0f"), new Guid("c69edb03-4fb6-4071-bcc5-f158808c69ee"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 1.5600000000000001 },
                    { new Guid("bd4f0ee5-be9f-4298-a043-8424dd6d62d3"), new Guid("c15c008f-f7f4-4dae-95bb-02a32bb2b8b1"), new Guid("fe85d6ab-ade6-412f-b2a6-7ca97f4f1da4"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 2.6099999999999999 },
                    { new Guid("bdeb4acc-667c-4ee9-a9db-8d20fd1d68eb"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("d7c7beea-3351-482b-82e1-8df4573395b9"), new Guid("cdd64d87-bb9a-4c17-b809-05c4454e6998"), 10.0 },
                    { new Guid("bec1c811-5198-4c74-bd9c-d1dfdfb56432"), new Guid("0c5fd362-b14d-4186-bef9-979ed21b9575"), new Guid("7a0822a4-7012-4738-889b-fafb713f72ea"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.6200000000000001 },
                    { new Guid("c339e10e-0121-49b7-93e6-2a9e29a99b9b"), new Guid("c15c008f-f7f4-4dae-95bb-02a32bb2b8b1"), new Guid("c69edb03-4fb6-4071-bcc5-f158808c69ee"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 0.0 },
                    { new Guid("c3dc44c9-1fbe-4630-bf9c-1f809a0519b9"), new Guid("0c5fd362-b14d-4186-bef9-979ed21b9575"), new Guid("74b32655-e330-4e74-a1a2-e1e92023f676"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 5.4800000000000004 },
                    { new Guid("c8003f13-5dad-401a-a001-bdf333f506ca"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("15140cfd-eacc-41f3-aae5-718980da88b9"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 4.96 },
                    { new Guid("c9e269e2-9faf-4e99-8066-08ee3c8b01d7"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("31f2f6d6-a5fa-4da3-adcf-0a5cc237eb95"), new Guid("63715754-cdfb-4320-9c17-72648673cb4b"), 7.0 },
                    { new Guid("cb749915-4840-4ec7-8973-6587fd5f6552"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("15140cfd-eacc-41f3-aae5-718980da88b9"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 2.48 },
                    { new Guid("cc0ca9a0-e14d-468a-8ca1-a58f23aaeda3"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("7a540a8b-0198-40d8-9185-2e02ba5eb1ab"), new Guid("63715754-cdfb-4320-9c17-72648673cb4b"), 6.0 },
                    { new Guid("cf453f03-5479-4396-ae8f-8d8f7bfa9283"), new Guid("b29fa523-bd56-48be-9adc-cbd23f0af646"), new Guid("b4a2b0b2-35c4-41d4-8ca7-1d2ebd1440e9"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 3.04 },
                    { new Guid("d244f6c3-2695-4a18-9ecf-7aeb9e3ad1f3"), new Guid("5540d80e-8fae-4afb-a475-b49c1a9c4c2e"), new Guid("73a3a716-f447-4057-99ca-1500d438ba58"), new Guid("63715754-cdfb-4320-9c17-72648673cb4b"), 4.0 },
                    { new Guid("d6d54404-f706-4535-af13-82bd6c0c3680"), new Guid("f5ad4a31-a240-41bd-bffd-245103b88d0f"), new Guid("15140cfd-eacc-41f3-aae5-718980da88b9"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 1.24 },
                    { new Guid("d6e01529-603a-40c8-95e8-33548f52de0f"), new Guid("f5ad4a31-a240-41bd-bffd-245103b88d0f"), new Guid("186476d2-772b-4eb1-b140-b0c1a238ae11"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 1.4099999999999999 },
                    { new Guid("d86fc321-ee82-4db9-b664-db9730395841"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("fe85d6ab-ade6-412f-b2a6-7ca97f4f1da4"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 0.87 },
                    { new Guid("d8f6e657-47d8-45eb-8cfa-50ef7f3b9094"), new Guid("1aa2ef63-41db-4f3d-aacd-e38c7e4639ac"), new Guid("74b32655-e330-4e74-a1a2-e1e92023f676"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 2.1899999999999999 },
                    { new Guid("dba6f127-5c75-4e38-8546-34e42089f6dd"), new Guid("0c5fd362-b14d-4186-bef9-979ed21b9575"), new Guid("c69edb03-4fb6-4071-bcc5-f158808c69ee"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 7.7999999999999998 },
                    { new Guid("df789397-c69c-4305-b33c-c49af5f8fa3a"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("7a540a8b-0198-40d8-9185-2e02ba5eb1ab"), new Guid("63715754-cdfb-4320-9c17-72648673cb4b"), 3.0 },
                    { new Guid("e77e1650-444e-4363-a3f2-1cb04ccb7b83"), new Guid("f5ad4a31-a240-41bd-bffd-245103b88d0f"), new Guid("74b32655-e330-4e74-a1a2-e1e92023f676"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 1.1000000000000001 },
                    { new Guid("ee1e1078-41b2-43fc-b2ae-d4121c2b7ca2"), new Guid("b3b0177d-baf9-4ad6-b1c1-002e1b776a10"), new Guid("24fbf4f3-aa84-4b17-9d2e-0ef16238a2ba"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.5900000000000001 },
                    { new Guid("f1bdbe86-1a83-4d68-99d6-bc5a2abcdc9a"), new Guid("0c5fd362-b14d-4186-bef9-979ed21b9575"), new Guid("186476d2-772b-4eb1-b140-b0c1a238ae11"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 7.0700000000000003 },
                    { new Guid("f73396af-6176-468d-abf3-d16555c63c3c"), new Guid("c15c008f-f7f4-4dae-95bb-02a32bb2b8b1"), new Guid("15140cfd-eacc-41f3-aae5-718980da88b9"), new Guid("eb8f98d6-1c46-4721-9ad6-c464b9029905"), 0.0 },
                    { new Guid("faf586cd-51bc-4a56-a10c-3d748355462c"), new Guid("b29fa523-bd56-48be-9adc-cbd23f0af646"), new Guid("7a0822a4-7012-4738-889b-fafb713f72ea"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.0 },
                    { new Guid("fb482a34-c3cf-40c9-9e34-72eac6668c4f"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("ea5a8d97-0940-4463-b07a-d6a10b6f0d08"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.1399999999999999 },
                    { new Guid("fbe342c7-9a7b-48d4-86bf-2cc9b32f3ac7"), new Guid("b29fa523-bd56-48be-9adc-cbd23f0af646"), new Guid("ea5a8d97-0940-4463-b07a-d6a10b6f0d08"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 1.0 },
                    { new Guid("ff79e6d5-606d-4d9f-a046-0157ff60de8c"), new Guid("fc6ea190-24a2-42d0-b2aa-783758efa82d"), new Guid("73a3a716-f447-4057-99ca-1500d438ba58"), new Guid("63715754-cdfb-4320-9c17-72648673cb4b"), 3.0 },
                    { new Guid("ff9377b2-17ac-4fbd-acbb-68b5aa4ea73a"), new Guid("c15c008f-f7f4-4dae-95bb-02a32bb2b8b1"), new Guid("4feab03a-7415-4c72-8b3f-6901e014c25e"), new Guid("b03771e5-488a-449f-b886-19c581b63cde"), 2.7200000000000002 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_CreatorId",
                table: "Applications",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_StatusId",
                table: "Applications",
                column: "StatusId");

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
                name: "IX_DifficultyLevels_EvaluationAttributeId",
                table: "DifficultyLevels",
                column: "EvaluationAttributeId");

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
                name: "IX_Evaluators_DepartmentId",
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
                name: "ApplicationForEvaluations");

            migrationBuilder.DropTable(
                name: "ApplicationToEvaluators");

            migrationBuilder.DropTable(
                name: "DifficultyLevels");

            migrationBuilder.DropTable(
                name: "EvaluatorToEvaluatedFactors");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "ProgramsParametrToSubjectAreaElements");

            migrationBuilder.DropTable(
                name: "EvaluationAttributes");

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
                name: "ApplicationStatuses");

            migrationBuilder.DropTable(
                name: "Evaluators");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
