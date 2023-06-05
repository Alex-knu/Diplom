using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.Router.API.Core.Interfaces
{
    public interface IBaseApplicationService
    {
        Task<BaseApplicationDTO> CreateBaseApplicationAsync(HttpContext httpContext, BaseApplicationDTO query);
        Task<BaseApplicationDTO> DeleteBaseApplicationAsync(Guid id);
        Task<IEnumerable<BaseApplicationDTO>> GetBaseApplicationsAsync(HttpContext httpContext);
        Task<BaseApplicationDTO> GetBaseApplicationsByIdAsync(Guid id);
        Task<BaseApplicationDTO> UpdateBaseApplicationAsync(BaseApplicationDTO query);
    }
}