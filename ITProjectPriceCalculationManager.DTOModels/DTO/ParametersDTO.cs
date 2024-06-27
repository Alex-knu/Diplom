namespace ITProjectPriceCalculationManager.DTOModels.DTO;

public class ParametersDTO
{
    public Guid Id { get; set; }
    public Guid ApplicationId { get; set; }
    public required string Name { get; set; }

    public List<EvaluateParameterDTO>? EvaluateParameters { get; set;  }
}