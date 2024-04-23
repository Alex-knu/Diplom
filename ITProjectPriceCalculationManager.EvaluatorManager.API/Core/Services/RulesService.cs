using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.Rules;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces.Repositories;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces.Services;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Services;

internal class RulesService : BaseService<Rules, Guid, RulesDTO>, IRulesService
{
    public RulesService(IRepository<Rules, Guid> repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<RulesDTO> CreateRulesAsync(RulesDTO Rules)
    {
        return await base.CreateEntityAsync(Rules);
    }

    public async Task<RulesDTO> DeleteRulesAsync(Guid id)
    {
        return await base.DeleteEntityAsync(id);
    }

    public Task<RulesDTO> GetRulesByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<RulesDTO>> GetRulesAsync()
    {
        return await base.GetEntitysAsync();
    }

    public async Task<RulesDTO> GetRulessByIdAsync(Guid id)
    {
        return await base.GetEntitysByIdAsync(id);
    }

    public async Task<RulesDTO> UpdateRulesAsync(RulesDTO Rules)
    {
        return await base.UpdateEntityAsync(Rules);
    }
}