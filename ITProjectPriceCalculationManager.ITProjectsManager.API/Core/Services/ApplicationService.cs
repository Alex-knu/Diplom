using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Application;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Repositories;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services
{
    internal class ApplicationService : BaseService<Application, int, ApplicationDTO>, IApplicationService
    {
        public ApplicationService(IRepository<Application, int> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public Task<ApplicationDTO> CreateApplicationAsync(ApplicationDTO application)
        {
            return base.CreateEntityAsync(application);
        }

        public Task<ApplicationDTO> DeleteApplicationAsync(int id)
        {
            return base.DeleteEntityAsync(id);
        }

        public Task<IEnumerable<ApplicationDTO>> GetApplicationsAsync()
        {
            return base.GetEntitysAsync();
        }

        public Task<ApplicationDTO> GetApplicationsByIdAsync(int id)
        {
            return base.GetEntitysByIdAsync(id);
        }

        public Task<ApplicationDTO> UpdateApplicationAsync(ApplicationDTO application)
        {
            return base.UpdateEntityAsync(application);
        }
    }
}