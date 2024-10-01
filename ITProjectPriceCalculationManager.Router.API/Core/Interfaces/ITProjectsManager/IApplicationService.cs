using ITProjectPriceCalculationManager.DTOModels.DTO.ITProjectsManager;

namespace ITProjectPriceCalculationManager.Router.API.Core.Interfaces.ITProjectsManager;

public interface IApplicationService
{
    Task<IEnumerable<BaseApplicationDTO>> GetApplicationsAsync();
    Task<BaseApplicationDTO> GetApplicationsByIdAsync(Guid id);
    Task<BaseApplicationDTO> CreateApplicationAsync(BaseApplicationDTO query);
    Task<BaseApplicationDTO> UpdateApplicationAsync(BaseApplicationDTO query);
    Task<BaseApplicationDTO> DeleteApplicationAsync(Guid id);
}