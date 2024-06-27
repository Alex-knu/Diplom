namespace ITProjectPriceCalculationManager.DTOModels.DTO;

public class EvaluationApplicationDTO
{
    public Guid UserCreatorId { get; set; }
    public required List<ApplicationToFactorsDTO> ApplicationToFactors { get; set; }
    public required List<ProgramInfoDTO> ProgramInfo { get; set; }
}