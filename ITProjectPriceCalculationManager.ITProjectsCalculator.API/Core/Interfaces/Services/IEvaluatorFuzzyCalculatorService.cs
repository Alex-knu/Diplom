using ITProjectPriceCalculationManager.DTOModels.DTO.FuzzyLogic;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Interfaces.Services;

public interface IEvaluatorFuzzyCalculatorService
{
    Task<double> Calculate(EvaluatorFuzzyQueryDTO evaluatorFuzzyQuery);
}