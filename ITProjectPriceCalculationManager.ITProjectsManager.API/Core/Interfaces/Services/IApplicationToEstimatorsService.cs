using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services
{
    public interface IApplicationToEstimatorsService
    {
        Task<ApplicationToEstimatorsDTO> CreateApplicationToEstimatorsAsync(ApplicationToEstimatorsDTO applicationToEstimators);
    }
}