namespace ITProjectPriceCalculationManager.DTOModels.DTO;

public class EvaluationApplicationDTO
{
    public Guid UserCreatorId { get; set; }
    public List<ApplicationToFactorsDTO> ApplicationToFactors { get; set; }
    public List<ProgramInfoDTO> ProgramInfo { get; set; }
}