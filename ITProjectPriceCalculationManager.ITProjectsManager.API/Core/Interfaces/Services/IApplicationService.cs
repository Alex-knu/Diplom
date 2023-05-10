using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services
{
    public interface IApplicationService
    {
        Task<IEnumerable<ApplicationDTO>> GetApplicationsAsync();
        Task<ApplicationDTO> GetApplicationsByIdAsync(int id);
        Task<ApplicationDTO> CreateApplicationAsync(ApplicationDTO dto);
        Task<ApplicationDTO> UpdateApplicationAsync(ApplicationDTO query);
        Task<ApplicationDTO> DeleteApplicationAsync(int id);
        
        Task<ApplicationDTO> CreateBaseApplicationAsync(BaseApplicationDTO baseApplication);
    }
}