namespace ITProjectPriceCalculationManager.DTOModels.DTO;

public class ApplicationToEstimatorsDTO
{
    public Guid ApplicationId { get; set; }
    public List<EvaluatorDTO> Evaluators { get; set; }
}