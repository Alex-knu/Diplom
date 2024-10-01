using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "BelongingFunctions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BelongingFunctions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Departments_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
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
                        name: "FK_Evaluators_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
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
                name: "ProcedureApplications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_ProcedureApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcedureApplications_ApplicationStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ApplicationStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcedureApplications_Evaluators_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Evaluators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EvaluatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Evaluators_EvaluatorId",
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
                    SelfEvaluation = table.Column<double>(type: "float", nullable: true),
                    ConfidenceArea = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationToEvaluators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationToEvaluators_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationToEvaluators_Evaluators_EvaluatorId",
                        column: x => x.EvaluatorId,
                        principalTable: "Evaluators",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Parameters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parameters_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvaluateParameters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BelongingFunctionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParameterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParameterValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluateParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluateParameters_BelongingFunctions_BelongingFunctionId",
                        column: x => x.BelongingFunctionId,
                        principalTable: "BelongingFunctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvaluateParameters_Parameters_ParameterId",
                        column: x => x.ParameterId,
                        principalTable: "Parameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvaluateParametersToAgents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParameterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluateParametersToAgents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluateParametersToAgents_Evaluators_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Evaluators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EvaluateParametersToAgents_Parameters_ParameterId",
                        column: x => x.ParameterId,
                        principalTable: "Parameters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ParameterValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    A = table.Column<float>(type: "real", nullable: false),
                    B = table.Column<float>(type: "real", nullable: false),
                    C = table.Column<float>(type: "real", nullable: false),
                    D = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParameterValues_EvaluateParameters_Id",
                        column: x => x.Id,
                        principalTable: "EvaluateParameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                table: "BelongingFunctions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6d8622f5-8e17-49a9-b66e-5e11fd761278"), "ExponentialMembershipFunction" },
                    { new Guid("9c4b86fc-0f8f-4e26-8de0-29c57b076a54"), "QuadraticMembershipFunction" },
                    { new Guid("a13bcaf8-0d49-4df7-ba32-0d6fd5b4c4c0"), "GaussianMembershipFunction" },
                    { new Guid("f4bf3d51-4f18-42e5-b92f-1e8cf40dca1a"), "SigmoidMembershipFunction" }
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
                name: "IX_Departments_ParentId",
                table: "Departments",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluateParameters_BelongingFunctionId",
                table: "EvaluateParameters",
                column: "BelongingFunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluateParameters_ParameterId",
                table: "EvaluateParameters",
                column: "ParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluateParametersToAgents_AgentId",
                table: "EvaluateParametersToAgents",
                column: "AgentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EvaluateParametersToAgents_ParameterId",
                table: "EvaluateParametersToAgents",
                column: "ParameterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Evaluators_DepartmentId",
                table: "Evaluators",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Parameters_ApplicationId",
                table: "Parameters",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcedureApplications_CreatorId",
                table: "ProcedureApplications",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcedureApplications_StatusId",
                table: "ProcedureApplications",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_EvaluatorId",
                table: "Profiles",
                column: "EvaluatorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationToEvaluators");

            migrationBuilder.DropTable(
                name: "EvaluateParametersToAgents");

            migrationBuilder.DropTable(
                name: "ParameterValues");

            migrationBuilder.DropTable(
                name: "ProcedureApplications");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "EvaluateParameters");

            migrationBuilder.DropTable(
                name: "BelongingFunctions");

            migrationBuilder.DropTable(
                name: "Parameters");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "ApplicationStatuses");

            migrationBuilder.DropTable(
                name: "Evaluators");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
