namespace ITProjectPriceCalculationManager.DTOModels.DTO;

public class EvaluatorFuzzyQueryDTO
{
    public required List<EvaluationCompetentValueDTO> EvaluationCompetentValues { get; set; }
    public required List<EvaluateParameterDTO> EvaluateParameters { get; set; }
}