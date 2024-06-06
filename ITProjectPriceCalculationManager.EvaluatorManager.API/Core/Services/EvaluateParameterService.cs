using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.EvaluateParameter;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces.Repositories;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces.Services;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Services;

internal class EvaluateParameterService : BaseService<EvaluateParameter, Guid, EvaluateParameterDTO>, IEvaluateParameterService
{
    public EvaluateParameterService(IRepository<EvaluateParameter, Guid> repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<EvaluateParameterDTO> CreateEvaluateParameterAsync(EvaluateParameterDTO EvaluateParameter)
    {
        return await base.CreateEntityAsync(EvaluateParameter);
    }

    public async Task<EvaluateParameterDTO> DeleteEvaluateParameterAsync(Guid id)
    {
        return await base.DeleteEntityAsync(id);
    }

    public Task<EvaluateParameterDTO> GetEvaluateParameterByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<EvaluateParameterDTO>> GetEvaluateParametersByParameterIdAsync(Guid parameterId)
    {
        var domainEntity = await _repository.GetAllAsync();

        return _mapper.Map<IEnumerable<EvaluateParameterDTO>>(domainEntity.Where(param => param.ParameterId == parameterId));
    }

    public async Task<IEnumerable<EvaluateParameterDTO>> GetEvaluateParameterAsync()
    {
        return await base.GetEntitysAsync();
    }

    public async Task<EvaluateParameterDTO> GetEvaluateParametersByIdAsync(Guid id)
    {
        return await base.GetEntitysByIdAsync(id);
    }

    public async Task<EvaluateParameterDTO> UpdateEvaluateParameterAsync(EvaluateParameterDTO EvaluateParameter)
    {
        return await base.UpdateEntityAsync(EvaluateParameter);
    }
}