namespace ITProjectPriceCalculationManager.DTOModels.DTO.FuzzyLogic;

public class EvaluatorFuzzyQueryDTO
{
    public required List<EvaluationCompetentValueDTO> EvaluationCompetentValues { get; set; }
    public required List<EvaluateParameterDTO> EvaluateParameters { get; set; }
}