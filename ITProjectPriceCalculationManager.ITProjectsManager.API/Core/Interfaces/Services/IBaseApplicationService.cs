using ITProjectPriceCalculationManager.DTOModels.DTO.ITProjectsManager;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;

public interface IBaseApplicationService
{
    Task<BaseApplicationDTO> CreateBaseApplicationAsync(BaseApplicationDTO baseApplication);
    Task<BaseApplicationDTO> DeleteBaseApplicationAsync(Guid id);
    Task<IEnumerable<BaseApplicationDTO>> GetBaseApplicationsAsync(HttpContext httpContext);
    Task<BaseApplicationDTO> GetBaseApplicationsByIdAsync(Guid id);
    Task<BaseApplicationDTO> UpdateBaseApplicationAsync(BaseApplicationDTO baseApplication);
}