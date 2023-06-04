using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.Router.API.Core.Interfaces
{
    public interface IApplicationToFactorsService
    {
        Task<EvaluationApplicationDTO> CreateApplicationToFactorsAsync(HttpContext httpContext, EvaluationApplicationDTO query);
    }
}