using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.EvaluateParameterValue;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces.Repositories;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces.Services;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Services;

internal class EvaluateParameterValueService : BaseService<EvaluateParameterValue, Guid, EvaluateParameterValueDTO>, IEvaluateParameterValueService
{
    public EvaluateParameterValueService(IRepository<EvaluateParameterValue, Guid> repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<EvaluateParameterValueDTO> CreateEvaluateParameterValueAsync(EvaluateParameterValueDTO EvaluateParameterValue)
    {
        return await base.CreateEntityAsync(EvaluateParameterValue);
    }

    public async Task<EvaluateParameterValueDTO> DeleteEvaluateParameterValueAsync(Guid id)
    {
        return await base.DeleteEntityAsync(id);
    }

    public Task<EvaluateParameterValueDTO> GetEvaluateParameterValueByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<EvaluateParameterValueDTO>> GetEvaluateParameterValueAsync()
    {
        return await base.GetEntitysAsync();
    }

    public async Task<EvaluateParameterValueDTO> GetEvaluateParameterValuesByIdAsync(Guid id)
    {
        return await base.GetEntitysByIdAsync(id);
    }

    public async Task<EvaluateParameterValueDTO> UpdateEvaluateParameterValueAsync(EvaluateParameterValueDTO EvaluateParameterValue)
    {
        return await base.UpdateEntityAsync(EvaluateParameterValue);
    }
}