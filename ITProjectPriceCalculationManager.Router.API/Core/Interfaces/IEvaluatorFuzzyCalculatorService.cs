using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.DTOModels.DTO.ITProjectsManager;

namespace ITProjectPriceCalculationManager.Router.API.Core.Interfaces;

public interface IEvaluatorFuzzyCalculatorService
{
    Task<ApplicationToEstimatorsDTO> Calculate(CalculateConfidenceAreaDTO evaluatorFuzzyQuery);
}