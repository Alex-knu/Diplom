using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Interfaces.Services
{
    public interface ICalculateService
    {
        Task<EvaluationResultDTO> Calculate(EvaluationDTO evaluation, double? price = null);
    }
}