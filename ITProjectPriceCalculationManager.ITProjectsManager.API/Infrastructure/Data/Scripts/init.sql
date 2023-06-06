CREATE PROCEDURE dbo.GetApplicationsByCreator @userId uniqueidentifier
AS
    SELECT a.*
    FROM dbo.Applications a
    INNER JOIN dbo.Evaluators e ON a.CreatorId = e.Id
    WHERE e.UserId = @userId
GO

CREATE PROCEDURE dbo.GetApplicationsByEvaluator @userId uniqueidentifier
AS
    SELECT a.*
    FROM dbo.Applications a
    INNER JOIN dbo.Evaluators e ON a.CreatorId = e.Id
    INNER JOIN dbo.ApplicationToEvaluators ate ON a.Id = ate.ApplicationId
    WHERE e.UserId = @userId
GO

CREATE PROCEDURE dbo.GetDifficultyLevelTypesForFactorType @factorTypeId uniqueidentifier
AS
    SELECT DISTINCT dlt.Id, dlt.Name
    FROM DifficultyLevelsTypeToFactorTypes dlttft
    INNER JOIN FactorTypes ft ON ft.Id = dlttft.FactorTypeId
    INNER JOIN DifficultyLevelsTypes dlt ON dlt.Id = dlttft.DifficultyLevelId
    WHERE ft.Id = @factorTypeId
    ORDER BY dlt.Id
GO

CREATE PROCEDURE dbo.GetEvaluationAttributes
AS
    SELECT DISTINCT a.Id, a.Id AS FactorId, a.Name, ft.Id AS FactorTypeId
    FROM DifficultyLevelsTypeToFactorTypes dlttft
    INNER JOIN Attributes a ON dlttft.FactorId = a.Id
    INNER JOIN FactorTypes ft ON dlttft.FactorTypeId = ft.Id
    ORDER BY a.Id
GO

CREATE PROCEDURE dbo.GetDifficultyLevel @factorId uniqueidentifier
AS
    SELECT dlt.Id AS Id, dlt.Id AS EvaluationAttributeId, dlttft.Id AS RelationId, dlt.Name
    FROM DifficultyLevelsTypeToFactorTypes dlttft
    INNER JOIN DifficultyLevelsTypes dlt ON dlttft.DifficultyLevelId = dlt.Id
    WHERE dlttft.FactorId = @factorId
GO