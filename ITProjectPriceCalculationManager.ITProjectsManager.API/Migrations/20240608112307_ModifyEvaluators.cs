using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Migrations
{
    /// <inheritdoc />
    public partial class ModifyEvaluators : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CompetencyLevel",
                table: "ApplicationToEvaluators",
                type: "float",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_ProcedureApplications_CreatorId",
                table: "ProcedureApplications",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcedureApplications_StatusId",
                table: "ProcedureApplications",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProcedureApplications");

            migrationBuilder.DropColumn(
                name: "CompetencyLevel",
                table: "ApplicationToEvaluators");
        }
    }
}
