using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.ParameterValue;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces.Services;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Infrastructure.Data;
using ITProjectPriceCalculationManager.Infrastructure.Interfaces;
using ITProjectPriceCalculationManager.Infrastructure.Services;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Services;

public class ParameterValueService : BaseService<ParameterValue, Guid, ParameterValueDTO, ITProjectPriceCalculationEvaluatorManagerDbContext>, IParameterValueService
{
    public ParameterValueService(IRepository<ParameterValue, Guid, ITProjectPriceCalculationEvaluatorManagerDbContext> repository, IMapper mapper) : base(repository, mapper)
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

    public async Task<ParameterValueDTO> GetParameterValuesByIdAsync(Guid id)
    {
        return await base.GetEntitysByIdAsync(id);
    }

    public async Task<ParameterValueDTO> UpdateParameterValueAsync(ParameterValueDTO ParameterValue)
    {
        return await base.UpdateEntityAsync(ParameterValue);
    }
}