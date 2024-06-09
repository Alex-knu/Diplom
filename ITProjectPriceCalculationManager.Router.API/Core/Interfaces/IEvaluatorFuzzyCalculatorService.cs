using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.Router.API.Core.Interfaces;

public interface IEvaluatorFuzzyCalculatorService
{
    Task<ApplicationToEstimatorsDTO> Calculate(CalculateConfidenceAreaDTO evaluatorFuzzyQuery);
}