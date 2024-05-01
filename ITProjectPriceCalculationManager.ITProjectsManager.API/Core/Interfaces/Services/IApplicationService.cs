using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;

public interface IApplicationService
{
    Task<IEnumerable<ApplicationDTO>> GetApplicationsAsync();
    Task<ApplicationDTO> GetApplicationsByIdAsync(Guid id);
    Task<ApplicationDTO> CreateApplicationAsync(ApplicationDTO dto);
    Task<ApplicationDTO> UpdateApplicationAsync(ApplicationDTO query);
    Task<ApplicationDTO> DeleteApplicationAsync(Guid id);
}