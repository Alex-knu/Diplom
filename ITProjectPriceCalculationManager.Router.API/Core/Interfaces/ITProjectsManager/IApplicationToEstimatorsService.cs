using ITProjectPriceCalculationManager.DTOModels.DTO.ITProjectsManager;

namespace ITProjectPriceCalculationManager.Router.API.Core.Interfaces.ITProjectsManager;

public interface IApplicationToEstimatorsService
{
    Task<IEnumerable<EvaluatorDTO>>  GetEstimatorGroupByApplicationId(Guid applicationId);
    Task<ApplicationToEstimatorsDTO> CreateApplicationToEstimatorsAsync(ApplicationToEstimatorsDTO query);
}