using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Application;
using ITProjectPriceCalculationManager.Infrastructure.Interfaces;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data;
using ITProjectPriceCalculationManager.Infrastructure.Services;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services;

internal class ApplicationService : BaseService<Application, Guid, ApplicationDTO, ITProjectPriceCalculationManagerDbContext>, IApplicationService
{
    public ApplicationService(IRepository<Application, Guid, ITProjectPriceCalculationManagerDbContext> repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<ApplicationDTO> CreateApplicationAsync(ApplicationDTO application)
    {
        return await base.CreateEntityAsync(application);
    }

    public async Task<ApplicationDTO> DeleteApplicationAsync(Guid id)
    {
        return await base.DeleteEntityAsync(id);
    }

    public async Task<IEnumerable<ApplicationDTO>> GetApplicationsAsync()
    {
        return await base.GetEntitysAsync();
    }

    public async Task<ApplicationDTO> GetApplicationsByIdAsync(Guid id)
    {
        return await base.GetEntitysByIdAsync(id);
    }

    public async Task<ApplicationDTO> UpdateApplicationAsync(ApplicationDTO application)
    {
        return await base.UpdateEntityAsync(application);
    }
}