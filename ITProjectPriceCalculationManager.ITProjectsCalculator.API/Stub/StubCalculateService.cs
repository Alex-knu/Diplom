using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.DTOModels.DTO.ITProjectsManager;
using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Interfaces.Services;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Stub;

public class StubCalculateService : ICalculateService
{
    public Task<EvaluationResultDTO> Calculate(EvaluationDTO evaluation, double? price = null)
    {
        return Task.FromResult(new EvaluationResultDTO
        {
            Result = 200000,
            Error = string.Empty
        });
    }
}