using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Application;
using ITProjectPriceCalculationManager.Infrastructure.Interfaces;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data;
using ITProjectPriceCalculationManager.Infrastructure.Services;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services;

internal class ApplicationService : BaseService<Application, Guid, BaseApplicationDTO, ITProjectPriceCalculationManagerDbContext>, IApplicationService
{
    public ApplicationService(IRepository<Application, Guid, ITProjectPriceCalculationManagerDbContext> repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<BaseApplicationDTO> CreateApplicationAsync(BaseApplicationDTO application)
    {
        return await base.CreateEntityAsync(application);
    }

    public async Task<BaseApplicationDTO> DeleteApplicationAsync(Guid id)
    {
        return await base.DeleteEntityAsync(id);
    }

    public async Task<IEnumerable<BaseApplicationDTO>> GetApplicationsAsync()
    {
        return await base.GetEntitysAsync();
    }

    public async Task<BaseApplicationDTO> GetApplicationsByIdAsync(Guid id)
    {
        return await base.GetEntitysByIdAsync(id);
    }

    public async Task<BaseApplicationDTO> UpdateApplicationAsync(BaseApplicationDTO application)
    {
        return await base.UpdateEntityAsync(application);
    }
}