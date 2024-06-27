namespace ITProjectPriceCalculationManager.DTOModels.DTO;

public class ExpertEvaluationDTO
{
    public Guid Id { get; set; }
    public double SelfEvaluation { get; set; }
    public required EvaluatorDTO Evaluator { get; set; }
    public required List<FactorDTO> ScaleFactors { get; set; }
    public required List<FactorDTO> InfluenceFactors { get; set; }
}