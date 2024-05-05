namespace ITProjectPriceCalculationManager.DTOModels.DTO;

public class EvaluateParameterDTO
{
    public string Name { get; set; }
    public Guid ApplicationId { get; set; }
    public Guid BelongingFunctionId { get; set; }
    public Guid ParameterId { get; set; }
    public Guid Id { get; set; }

    public EvaluateParameterValueDTO EvaluateParameterValue { get; set; }
}