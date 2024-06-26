using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.EvaluateParameter;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.Parameters;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.ParameterValue;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces.Repositories;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces.Services;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Services;

internal class ParametersService : BaseService<Parameters, Guid, ParametersDTO>, IParametersService
{
    private readonly IRepository<EvaluateParameter, Guid> _evaluateParameterRepository;
    private readonly IRepository<ParameterValue, Guid> _parameterValueRepository;
    
    public ParametersService(IRepository<EvaluateParameter, Guid> evaluateParameterRepository, IRepository<ParameterValue, Guid> parameterValueRepository, IRepository<Parameters, Guid> repository, IMapper mapper) : base(repository, mapper)
    {
        _evaluateParameterRepository = evaluateParameterRepository;
        _parameterValueRepository = parameterValueRepository;
    }

    public async Task<ParametersDTO> CreateParametersAsync(ParametersDTO Parameters)
    {
        return await base.CreateEntityAsync(Parameters);
    }

    public async Task<ParametersDTO> DeleteParametersAsync(Guid id)
    {
        return await base.DeleteEntityAsync(id);
    }

    public Task<ParametersDTO> GetParametersByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ParametersDTO>> GetParametersAsync()
    {
        return await base.GetEntitysAsync();
    }

    public async Task<ParametersDTO> GetParameterssByIdAsync(Guid id)
    {
        return await base.GetEntitysByIdAsync(id);
    }

    public async Task<ParametersDTO> UpdateParametersAsync(ParametersDTO Parameters)
    {
        return await base.UpdateEntityAsync(Parameters);
    }

    public async Task<IEnumerable<ParametersDTO>> GetParametersByApplicationIdAsync(Guid applicationId)
    {
        var domainEntities =  (await _repository.GetAllAsync()).Where(param => param.ApplicationId == applicationId);

        foreach (var domainEntity in domainEntities)
        {
            domainEntity.EvaluateParameters = (await _evaluateParameterRepository.GetAllAsync())
                .Where(ep => ep.ParameterId == domainEntity.Id).ToList();
        }

        foreach (var evaluateParameter in domainEntities.SelectMany(e => e.EvaluateParameters))
        {
            evaluateParameter.EvaluateParameterValue = (await _parameterValueRepository.GetAllAsync())
                .Where(pv => pv.Id == evaluateParameter.Id).SingleOrDefault();
        }
        
        return _mapper.Map<IEnumerable<ParametersDTO>>(domainEntities);
    }
}