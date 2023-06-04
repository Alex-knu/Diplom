CREATE PROCEDURE dbo.GetApplicationsByCreator @userId uniqueidentifier
AS
SELECT a.*
FROM dbo.Applications a
JOIN dbo.Evaluators e ON a.CreatorId = e.Id
WHERE e.UserId = @userId
GO

CREATE PROCEDURE dbo.GetApplicationsByEvaluator @userId uniqueidentifier
AS
SELECT a.*
FROM dbo.Applications a
JOIN dbo.Evaluators e ON a.CreatorId = e.Id
JOIN dbo.ApplicationToEvaluators ate ON a.Id = ate.ApplicationId
WHERE e.UserId = @userId
GO