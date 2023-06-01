using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services
{
    public interface IApplicationToFactorsService
    {
        Task<EvaluationApplicationDTO> CreateApplicationToFactorsAsync(EvaluationApplicationDTO applicationToFactors);
    }
}