using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services
{
    public interface IBaseApplicationService
    {
        Task<BaseApplicationDTO> CreateBaseApplicationAsync(BaseApplicationDTO baseApplication);
        Task<BaseApplicationDTO> DeleteBaseApplicationAsync(int id);
        Task<IEnumerable<BaseApplicationDTO>> GetBaseApplicationsAsync();
        Task<BaseApplicationDTO> GetBaseApplicationsByIdAsync(int id);
        Task<BaseApplicationDTO> UpdateBaseApplicationAsync(BaseApplicationDTO baseApplication);
    }
}