using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.EvaluateParameter;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces.Services;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Infrastructure.Data;
using ITProjectPriceCalculationManager.Infrastructure.Interfaces;
using ITProjectPriceCalculationManager.Infrastructure.Services;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Services;

public class EvaluateParameterService : BaseService<EvaluateParameter, Guid, EvaluateParameterDTO, ITProjectPriceCalculationEvaluatorManagerDbContext>, IEvaluateParameterService
{
    private readonly IParameterValueService _parameterValueService;

    public EvaluateParameterService(IParameterValueService parameterValueService, IRepository<EvaluateParameter, Guid, ITProjectPriceCalculationEvaluatorManagerDbContext> repository, IMapper mapper) : base(repository, mapper)
    {
        _parameterValueService = parameterValueService;
    }

    public async Task<EvaluateParameterDTO> CreateEvaluateParameterAsync(EvaluateParameterDTO EvaluateParameter)
    {
        var entity = await base.CreateEntityAsync(EvaluateParameter);

        if (EvaluateParameter.EvaluateParameterValue != null)
        {
            entity.EvaluateParameterValue = await _parameterValueService
                .GetParameterValueByIdAsync(EvaluateParameter.EvaluateParameterValue.Id);
        }

        return entity;
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