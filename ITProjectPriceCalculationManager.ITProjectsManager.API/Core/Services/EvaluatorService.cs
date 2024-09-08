using AutoMapper;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Evaluator;
using ITProjectPriceCalculationManager.Infrastructure.Interfaces;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data;
using ITProjectPriceCalculationManager.Infrastructure.Services;
using ITProjectPriceCalculationManager.DTOModels.DTO.ITProjectsManager;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services;

internal class EvaluatorService : BaseService<Evaluator, Guid, EvaluatorDTO, ITProjectPriceCalculationManagerDbContext>, IEvaluatorService
{
    public EvaluatorService(IRepository<Evaluator, Guid, ITProjectPriceCalculationManagerDbContext> repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<EvaluatorDTO> CreateEvaluatorAsync(EvaluatorDTO evaluator)
    {
        return await base.CreateEntityAsync(evaluator);
    }

    public async Task<EvaluatorDTO> DeleteEvaluatorAsync(Guid id)
    {
        return await base.DeleteEntityAsync(id);
    }

    public async Task<IEnumerable<EvaluatorDTO>> GetEvaluatorsAsync(List<Guid> userIds)
    {
        return (await base.GetEntityListBySpecAsync(new Evaluators.GetEvaluatorsWithDependencies())).Where(evaluator =>
            userIds.Contains(evaluator.UserId));
    }

    public async Task<EvaluatorDTO> GetEvaluatorsByIdAsync(Guid id)
    {
        return await base.GetEntitysByIdAsync(id);
    }

    public async Task<EvaluatorDTO> UpdateEvaluatorAsync(EvaluatorDTO evaluator)
    {
        return await base.UpdateEntityAsync(evaluator);
    }
}