using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO.FuzzyLogic;
using ITProjectPriceCalculationManager.Infrastructure.Interfaces;
using ITProjectPriceCalculationManager.Infrastructure.Services;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.EvaluateParameter;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Parameter;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ParameterValue;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services;

internal class ParametersService : BaseService<Parameter, Guid, ParametersDTO, ITProjectPriceCalculationManagerDbContext>, IParametersService
{
    private readonly IRepository<EvaluateParameter, Guid, ITProjectPriceCalculationManagerDbContext> _evaluateParameterRepository;
    private readonly IRepository<ParameterValue, Guid, ITProjectPriceCalculationManagerDbContext> _parameterValueRepository;
    
    public ParametersService(
        IRepository<EvaluateParameter, Guid, ITProjectPriceCalculationManagerDbContext> evaluateParameterRepository, 
        IRepository<ParameterValue, Guid, ITProjectPriceCalculationManagerDbContext> parameterValueRepository, 
        IRepository<Parameter, Guid, ITProjectPriceCalculationManagerDbContext> repository, IMapper mapper) : base(repository, mapper)
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

        foreach (var evaluateParameter in domainEntities.SelectMany(e => e.EvaluateParameters ?? Enumerable.Empty<EvaluateParameter>()))
        {
            evaluateParameter.EvaluateParameterValue = (await _parameterValueRepository.GetAllAsync())
                .Where(pv => pv.Id == evaluateParameter.Id).Single();
        }
        
        return _mapper.Map<IEnumerable<ParametersDTO>>(domainEntities);
    }
}
