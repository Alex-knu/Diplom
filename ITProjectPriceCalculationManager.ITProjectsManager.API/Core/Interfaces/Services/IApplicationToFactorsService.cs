using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services
{
    public interface IApplicationToFactorsService
    {
        Task<EvaluationApplicationDTO> CreateApplicationToFactorsAsync(EvaluationApplicationDTO applicationToFactors);
    }
}