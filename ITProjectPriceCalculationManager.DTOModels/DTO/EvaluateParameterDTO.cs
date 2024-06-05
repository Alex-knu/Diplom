namespace ITProjectPriceCalculationManager.DTOModels.DTO;

public class EvaluateParameterDTO
{
    public string Name { get; set; }
    public Guid BelongingFunctionId { get; set; }
    public Guid ParameterId { get; set; }
    public Guid Id { get; set; }

    public ParameterValueDTO EvaluateParameterValue { get; set; }
}