using ITProjectPriceCalculationManager.DTOModels.DTO.ITProjectsManager;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;

public interface IApplicationService
{
    Task<IEnumerable<BaseApplicationDTO>> GetApplicationsAsync();
    Task<BaseApplicationDTO> GetApplicationsByIdAsync(Guid id);
    Task<BaseApplicationDTO> CreateApplicationAsync(BaseApplicationDTO dto);
    Task<BaseApplicationDTO> UpdateApplicationAsync(BaseApplicationDTO query);
    Task<BaseApplicationDTO> DeleteApplicationAsync(Guid id);
}