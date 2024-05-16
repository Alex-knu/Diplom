using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Migrations
{
    /// <inheritdoc />
    public partial class AddStoredProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE PROCEDURE dbo.GetApplicationsByCreator
                @userId uniqueidentifier
            AS
            SELECT a.*, ApS.Name AS StatusName
            FROM dbo.Applications a
                INNER JOIN dbo.Evaluators e ON a.CreatorId = e.Id
                INNER JOIN dbo.ApplicationStatuses ApS ON ApS.Id = a.StatusId
            WHERE e.UserId = @userId
            ");
            migrationBuilder.Sql(@"
            CREATE PROCEDURE dbo.GetApplicationsByEvaluator
                @userId uniqueidentifier
            AS
            SELECT a.*, ApS.Name AS StatusName
            FROM dbo.Applications a
                INNER JOIN dbo.ApplicationToEvaluators ate ON a.Id = ate.ApplicationId
                INNER JOIN dbo.Evaluators e ON ate.EvaluatorId = e.Id
            INNER JOIN dbo.ApplicationStatuses ApS on ApS.Id = a.StatusId
            WHERE e.UserId = @userId
            GO
            ");
            migrationBuilder.Sql(@"
            CREATE PROCEDURE dbo.GetDifficultyLevelTypesForFactorType
                @factorTypeId uniqueidentifier
            AS
            SELECT DISTINCT dlt.Id, dlt.Name
            FROM DifficultyLevelsTypeToFactorTypes dlttft
                INNER JOIN FactorTypes ft ON ft.Id = dlttft.FactorTypeId
                INNER JOIN DifficultyLevelsTypes dlt ON dlt.Id = dlttft.DifficultyLevelId
            WHERE ft.Id = @factorTypeId
            ORDER BY dlt.Id
            GO
            ");
            migrationBuilder.Sql(@"
            CREATE PROCEDURE dbo.GetEvaluationAttributes
            AS
            SELECT DISTINCT a.Id, a.Id AS FactorId, a.Name, ft.Id AS FactorTypeId
            FROM DifficultyLevelsTypeToFactorTypes dlttft
                INNER JOIN Attributes a ON dlttft.FactorId = a.Id
                INNER JOIN FactorTypes ft ON dlttft.FactorTypeId = ft.Id
            ORDER BY a.Id
            GO
            ");
            migrationBuilder.Sql(@"
            CREATE PROCEDURE dbo.GetDifficultyLevel
                @factorId uniqueidentifier
            AS
            SELECT dlt.Id AS Id, dlt.Id AS EvaluationAttributeId, dlttft.Id AS RelationId, dlt.Name
            FROM DifficultyLevelsTypeToFactorTypes dlttft
                INNER JOIN DifficultyLevelsTypes dlt ON dlttft.DifficultyLevelId = dlt.Id
            WHERE dlttft.FactorId = @factorId
            ORDER BY dlt.Name
            GO
            ");
            migrationBuilder.Sql(@"
            CREATE PROCEDURE dbo.GetApplicationsByIdForEvaluation 
                @applicationId uniqueidentifier
            AS
            BEGIN
                BEGIN
                    SELECT Id, Profit, Overhead, SocialInsurance, AverageCostLabor, AverageMonthlyRateWorkingHours, ConfidenceArea
                    FROM Applications
                    WHERE Id = @applicationId
                END
            END
            ");
            migrationBuilder.Sql(@"
            CREATE PROCEDURE dbo.GetAllProgramLanguagesByApplicationId 
                @applicationId uniqueidentifier
            AS
                SELECT pp.Id, pl.Name, pl.SLOC
                FROM ProgramLanguages pl
                INNER JOIN ProgramsParametrs pp ON pl.Id = pp.ProgramLanguageId
                WHERE pp.ApplicationId = @applicationId
            GO
            ");
            migrationBuilder.Sql(@"
            CREATE PROCEDURE dbo.GetApplicationsByAdmin
            AS
            SELECT a.*, ApS.Name AS StatusName
            FROM dbo.Applications a
            INNER JOIN dbo.ApplicationStatuses ApS on ApS.Id = a.StatusId
            GO
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE dbo.GetApplicationsByCreator");
            migrationBuilder.Sql("DROP PROCEDURE dbo.GetApplicationsByEvaluator");
            migrationBuilder.Sql("DROP PROCEDURE dbo.GetDifficultyLevelTypesForFactorType");
            migrationBuilder.Sql("DROP PROCEDURE dbo.GetEvaluationAttributes");
            migrationBuilder.Sql("DROP PROCEDURE dbo.GetDifficultyLevel");
            migrationBuilder.Sql("DROP PROCEDURE dbo.GetApplicationsByIdForEvaluation");
            migrationBuilder.Sql("DROP PROCEDURE dbo.GetApplicationsByAdmin");
        }
    }
}
