using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.Parameters;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces.Repositories;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces.Services;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Services;

internal class ParametersService : BaseService<Parameters, Guid, ParametersDTO>, IParametersService
{
    public ParametersService(IRepository<Parameters, Guid> repository, IMapper mapper) : base(repository, mapper)
    {
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
        var domainEntity = await _repository.GetAllAsync();

        return _mapper.Map<IEnumerable<ParametersDTO>>(domainEntity.Where(param => param.ApplicationId == applicationId));
    }
}