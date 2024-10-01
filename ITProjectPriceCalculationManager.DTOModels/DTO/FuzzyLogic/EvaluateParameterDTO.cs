namespace ITProjectPriceCalculationManager.DTOModels.DTO.FuzzyLogic;

public class EvaluateParameterDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public Guid BelongingFunctionId { get; set; }
    public Guid ParameterId { get; set; }

    public BelongingFunctionDTO? BelongingFunction { get; set; }
    public ParameterValueDTO? EvaluateParameterValue { get; set; }
}