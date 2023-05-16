using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Application;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Repositories;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services
{
    internal class BaseApplicationService : BaseService<Application, int, BaseApplicationDTO>, IBaseApplicationService
    {
        public BaseApplicationService(IRepository<Application, int> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public Task<BaseApplicationDTO> CreateBaseApplicationAsync(BaseApplicationDTO baseApplication)
        {
            return base.CreateEntityAsync(baseApplication);
        }

        public Task<BaseApplicationDTO> DeleteBaseApplicationAsync(int id)
        {
            return base.DeleteEntityAsync(id);
        }

        public Task<IEnumerable<BaseApplicationDTO>> GetBaseApplicationsAsync()
        {
            return base.GetEntitysAsync();
        }

        public Task<BaseApplicationDTO> GetBaseApplicationsByIdAsync(int id)
        {
            return base.GetEntitysByIdAsync(id);
        }

        public Task<BaseApplicationDTO> UpdateBaseApplicationAsync(BaseApplicationDTO baseApplication)
        {
            return base.UpdateEntityAsync(baseApplication);
        }
    }
}