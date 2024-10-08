using ITProjectPriceCalculationManager.DTOModels.DTO.ITProjectsManager;

namespace ITProjectPriceCalculationManager.Router.API.Core.Interfaces.ITProjectsManager;

public interface IBaseApplicationService
{
    Task<BaseApplicationDTO> CreateBaseApplicationAsync(HttpContext httpContext, BaseApplicationDTO query);
    Task<BaseApplicationDTO> DeleteBaseApplicationAsync(Guid id);
    Task<IEnumerable<BaseApplicationDTO>> GetBaseApplicationsAsync(HttpContext httpContext);
    Task<BaseApplicationDTO> GetBaseApplicationsByIdAsync(Guid id);
    Task<BaseApplicationDTO> UpdateBaseApplicationAsync(BaseApplicationDTO query);
}