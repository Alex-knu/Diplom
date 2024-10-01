using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.DTOModels.DTO.ITProjectsManager;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Interfaces.Services;

public interface ICalculateService
{
    Task<EvaluationResultDTO> Calculate(EvaluationDTO evaluation, double? price = null);
}