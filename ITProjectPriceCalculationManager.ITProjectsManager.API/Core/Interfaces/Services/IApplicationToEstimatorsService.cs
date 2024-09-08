using ITProjectPriceCalculationManager.DTOModels.DTO.ITProjectsManager;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;

public interface IApplicationToEstimatorsService
{
    Task<IEnumerable<EvaluatorDTO>>  GetEstimatorGroupByApplicationId(Guid applicationId);
    Task<ApplicationToEstimatorsDTO> CreateApplicationToEstimatorsAsync(
        ApplicationToEstimatorsDTO applicationToEstimators);
    Task<ApplicationToEstimatorsDTO> UpdateApplicationToEstimatorsAsync(
        ApplicationToEstimatorsDTO applicationToEstimators);
}