using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompetencyLevel",
                table: "ApplicationToEvaluators",
                newName: "ConfidenceArea");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConfidenceArea",
                table: "ApplicationToEvaluators",
                newName: "CompetencyLevel");
        }
    }
}
