namespace ITProjectPriceCalculationManager.DTOModels.DTO;

public class EvaluationCompetentValueDTO
{
    public Guid Id { get; set; }
    public Guid EvaluationId { get; set; }
    public Guid EvaluationParameterId { get; set; }
    public double Value { get; set; }
}