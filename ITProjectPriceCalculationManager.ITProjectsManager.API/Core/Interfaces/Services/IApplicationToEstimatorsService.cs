using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;

public interface IApplicationToEstimatorsService
{
    Task<IEnumerable<EvaluatorDTO>>  GetEstimatorGroupByApplicationId(Guid applicationId);
    Task<ApplicationToEstimatorsDTO> CreateApplicationToEstimatorsAsync(
        ApplicationToEstimatorsDTO applicationToEstimators);
}