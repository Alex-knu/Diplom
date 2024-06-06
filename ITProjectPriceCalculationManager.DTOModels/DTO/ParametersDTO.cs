namespace ITProjectPriceCalculationManager.DTOModels.DTO;

public class ParametersDTO
{
    public Guid ApplicationId { get; set; }
    public string Name { get; set; }
    public Guid Id { get; set; }

    public List<EvaluateParameterDTO>? EvaluateParameters { get; set;  }
}