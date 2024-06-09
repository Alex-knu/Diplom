namespace ITProjectPriceCalculationManager.DTOModels.DTO;

public class CalculateConfidenceAreaDTO
{
    public Guid ApplicationId { get; set; }
    public Guid EvaluatorId { get; set; }
    public List<EvaluationCompetentValueDTO> EvaluationCompetentValues { get; set; }
}