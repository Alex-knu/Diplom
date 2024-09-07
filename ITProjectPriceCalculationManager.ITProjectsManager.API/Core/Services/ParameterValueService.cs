using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Infrastructure.Interfaces;
using ITProjectPriceCalculationManager.Infrastructure.Services;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ParameterValue;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services;

internal class ParameterValueService : BaseService<ParameterValue, Guid, ParameterValueDTO, ITProjectPriceCalculationManagerDbContext>, IParameterValueService
{
    public ParameterValueService(IRepository<ParameterValue, Guid, ITProjectPriceCalculationManagerDbContext> repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<ParameterValueDTO> CreateParameterValueAsync(ParameterValueDTO ParameterValue)
    {
        return await base.CreateEntityAsync(ParameterValue);
    }

    public async Task<ParameterValueDTO> DeleteParameterValueAsync(Guid id)
    {
        return await base.DeleteEntityAsync(id);
    }

    public async Task<ParameterValueDTO> GetParameterValueByIdAsync(Guid id)
    {
        return await base.GetEntitysByIdAsync(id);
    }

    public async Task<IEnumerable<ParameterValueDTO>> GetParameterValueAsync()
    {
        return await base.GetEntitysAsync();
    }

    public async Task<ParameterValueDTO> UpdateParameterValueAsync(ParameterValueDTO ParameterValue)
    {
        return await base.UpdateEntityAsync(ParameterValue);
    }
}