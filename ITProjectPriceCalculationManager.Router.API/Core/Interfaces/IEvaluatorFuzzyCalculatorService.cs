using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.Router.API.Core.Interfaces;

public interface IEvaluatorFuzzyCalculatorService
{
    Task<double> Calculate(List<EvaluationCompetentValueDTO> evaluationCompetentValues, List<EvaluateParameterDTO> evaluateParameters);
}