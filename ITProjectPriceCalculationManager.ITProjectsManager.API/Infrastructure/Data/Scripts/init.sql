USE "ITProjectPriceCalculationManager";

CREATE OR REPLACE FUNCTION GetDifficultyLevelTypesForFactorType(factorTypeId INT)
RETURNS TABLE (Id INTEGER, Name TEXT)
AS $$
BEGIN
    SELECT DISTINCT dlt.Name, dlt.Id
    FROM DifficultyLevelsTypeToFactorTypes dlttft
    JOIN FactorTypes ft ON ft.Id = dlttft.FactorTypeId
    JOIN DifficultyLevelsTypes dlt ON dlt.Id = dlttft.DifficultyLevelId
    WHERE ft.Id = @factorTypeId
    ORDER BY dlt.Id;
END;
$$ LANGUAGE plpgsql;