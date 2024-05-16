using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.Router.API.Core.Interfaces;

public interface IEvaluatorFuzzyCalculatorService
{
    Task<double> Calculate(EvaluatorFuzzyQueryDTO evaluatorFuzzyQuery);
}