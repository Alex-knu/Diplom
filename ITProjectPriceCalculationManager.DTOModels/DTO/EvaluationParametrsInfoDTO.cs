namespace ITProjectPriceCalculationManager.DTOModels.DTO;

public class EvaluationParametrsInfoDTO
{
    public required string Name { get; set; }
    public int FactorTypeId { get; set; }
    public required List<DifficultyLevelsTypeDTO> DifficultyLevels { get; set; }
}