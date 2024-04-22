using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.Router.API.Core.Interfaces;

public interface IApplicationService
{
    Task<IEnumerable<ApplicationDTO>> GetApplicationsAsync();
    Task<ApplicationDTO> GetApplicationsByIdAsync(Guid id);
    Task<ApplicationDTO> CreateApplicationAsync(ApplicationDTO query);
    Task<ApplicationDTO> UpdateApplicationAsync(ApplicationDTO query);
    Task<ApplicationDTO> DeleteApplicationAsync(Guid id);
}