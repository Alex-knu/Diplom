using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationsView : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        // Create the view
        migrationBuilder.Sql(@"
            CREATE VIEW dbo.ApplicationsTableView
            AS
            SELECT 
                a.Id, 
                a.CreatorId, 
                eCreator.UserId AS CreatorUserId, 
                a.StatusId,
                a.Name,
                a.Price,
                ApS.Name AS StatusName,
                eEvaluator.UserId AS EvaluatorUserId
            FROM dbo.Applications a
            INNER JOIN dbo.ApplicationStatuses ApS ON ApS.Id = a.StatusId
            LEFT JOIN dbo.Evaluators eCreator ON a.CreatorId = eCreator.Id
            LEFT JOIN dbo.ApplicationToEvaluators ate ON a.Id = ate.ApplicationId
            LEFT JOIN dbo.Evaluators eEvaluator ON ate.EvaluatorId = eEvaluator.Id;
        ");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        // Drop the view in case of rollback
        migrationBuilder.Sql("DROP VIEW IF EXISTS dbo.Vw_Applications;");
    }
}
}
