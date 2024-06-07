using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Migrations
{
    /// <inheritdoc />
    public partial class InitDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BelongingFunction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BelongingFunction", x => x.Id);
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
                });

            migrationBuilder.CreateTable(
                name: "EvaluateParameter",
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
                    table.PrimaryKey("PK_EvaluateParameter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluateParameter_BelongingFunction_BelongingFunctionId",
                        column: x => x.BelongingFunctionId,
                        principalTable: "BelongingFunction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvaluateParameter_Parameters_ParameterId",
                        column: x => x.ParameterId,
                        principalTable: "Parameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParameterValue",
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
                    table.PrimaryKey("PK_ParameterValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParameterValue_EvaluateParameter_Id",
                        column: x => x.Id,
                        principalTable: "EvaluateParameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BelongingFunction",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6d8622f5-8e17-49a9-b66e-5e11fd761278"), "ExponentialMembershipFunction" },
                    { new Guid("9c4b86fc-0f8f-4e26-8de0-29c57b076a54"), "QuadraticMembershipFunction" },
                    { new Guid("a13bcaf8-0d49-4df7-ba32-0d6fd5b4c4c0"), "GaussianMembershipFunction" },
                    { new Guid("f4bf3d51-4f18-42e5-b92f-1e8cf40dca1a"), "SigmoidMembershipFunction" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EvaluateParameter_BelongingFunctionId",
                table: "EvaluateParameter",
                column: "BelongingFunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluateParameter_ParameterId",
                table: "EvaluateParameter",
                column: "ParameterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParameterValue");

            migrationBuilder.DropTable(
                name: "EvaluateParameter");

            migrationBuilder.DropTable(
                name: "BelongingFunction");

            migrationBuilder.DropTable(
                name: "Parameters");
        }
    }
}
