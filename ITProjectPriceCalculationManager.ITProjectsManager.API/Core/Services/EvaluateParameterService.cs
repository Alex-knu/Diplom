using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO.FuzzyLogic;
using ITProjectPriceCalculationManager.Infrastructure.Interfaces;
using ITProjectPriceCalculationManager.Infrastructure.Services;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.EvaluateParameter;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services;

internal class EvaluateParameterService : BaseService<EvaluateParameter, Guid, EvaluateParameterDTO, ITProjectPriceCalculationManagerDbContext>, IEvaluateParameterService
{
    private readonly IParameterValueService _parameterValueService;

    public EvaluateParameterService(IParameterValueService parameterValueService, IRepository<EvaluateParameter, Guid, ITProjectPriceCalculationManagerDbContext> repository, IMapper mapper) : base(repository, mapper)
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