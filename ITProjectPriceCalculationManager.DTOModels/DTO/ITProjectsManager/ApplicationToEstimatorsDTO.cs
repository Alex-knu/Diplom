namespace ITProjectPriceCalculationManager.DTOModels.DTO.ITProjectsManager;

public class ApplicationToEstimatorsDTO
{
    public Guid Id { get; set; }
    public Guid ApplicationId { get; set; }
    public Guid? EvaluatorId { get; set; }
    public double? ConfidenceArea { get; set; }
    
    public List<EvaluatorDTO>? Evaluators { get; set; }
}