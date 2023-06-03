CREATE OR REPLACE FUNCTION GetDifficultyLevelTypesForFactorType(factorTypeId INT)
    RETURNS TABLE (
        Id INTEGER, 
        Name TEXT
    ) AS $$
    BEGIN
        RETURN QUERY
        SELECT DISTINCT  dlt."Id", dlt."Name"
        FROM "DifficultyLevelsTypeToFactorTypes" dlttft
        JOIN "FactorTypes" ft ON ft."Id" = dlttft."FactorTypeId"
        JOIN "DifficultyLevelsTypes" dlt ON dlt."Id" = dlttft."DifficultyLevelId"
        WHERE ft."Id" = @factorTypeId
        ORDER BY dlt."Id";
    END;
$$ LANGUAGE plpgsql;


CREATE OR REPLACE FUNCTION GetEvaluationAttributes()
    RETURNS TABLE (
        FactorId INTEGER,
        Name TEXT,
        FactorTypeId INTEGER
    ) AS $$
    BEGIN
        RETURN QUERY
        SELECT DISTINCT a."Id", a."Name", ft."Id" AS "FactorTypeId"
        FROM
        "DifficultyLevelsTypeToFactorTypes" dlttft
        JOIN "Attributes" a ON dlttft."FactorId" = a."Id"
        JOIN "FactorTypes" ft ON dlttft."FactorTypeId" = ft."Id"
        ORDER BY a."Id";
    END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION GetDifficultyLevel(factorId INTEGER)
    RETURNS TABLE (
        Id INTEGER,
        RelationId INTEGER,
        Name TEXT
    ) AS $$
    BEGIN
        RETURN QUERY
        SELECT dlt."Id", dlttft."Id" AS RelationId, dlt."Name"
        FROM "DifficultyLevelsTypeToFactorTypes" dlttft
        JOIN "DifficultyLevelsTypes" dlt ON dlttft."DifficultyLevelId" = dlt."Id"
        WHERE dlttft."FactorId" = @factorId;
    END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION GetApplicationsByCreator(userId VARCHAR)
    RETURNS TABLE (
        Id INTEGER,
        Name TEXT,
        Status TEXT
    ) AS $$
    BEGIN
        RETURN QUERY
        SELECT dlt."Id", dlttft."Id" AS RelationId, dlt."Name"
        FROM "Applications" a 
        JOIN "Estimators" e on a."CreatorId" = e."Id"
        WHERE e."UserId" = @userId;
    END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION GetApplicationsByEvaluator(userId VARCHAR)
    RETURNS TABLE (
        Id INTEGER,
        Name TEXT,
        Status TEXT
    ) AS $$
    BEGIN
        RETURN QUERY
        SELECT dlt."Id", dlttft."Id" AS RelationId, dlt."Name"
        FROM "Applications" a 
        JOIN "ApplicationToEstimators" ate ON ate."ApplicationId" = a."Id"
        JOIN "Estimators" e on ate."EstimatorId" = e."Id"
        WHERE e."UserId" = @userId;
    END;
$$ LANGUAGE plpgsql;