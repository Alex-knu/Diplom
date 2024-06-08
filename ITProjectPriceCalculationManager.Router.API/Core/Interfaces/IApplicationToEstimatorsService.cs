using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.Router.API.Core.Interfaces;

public interface IApplicationToEstimatorsService
{
    Task<IEnumerable<EvaluatorDTO>>  GetEstimatorGroupByApplicationId(Guid applicationId);
    Task<ApplicationToEstimatorsDTO> CreateApplicationToEstimatorsAsync(ApplicationToEstimatorsDTO query);
}