using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Evaluator;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Repositories;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services
{
    internal class EvaluatorService : BaseService<Evaluator, Guid, EvaluatorDTO>, IEvaluatorService
    {
        public EvaluatorService(IRepository<Evaluator, Guid> repository, IMapper mapper) : base(repository, mapper)
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
            return from evaluator in await base.GetEntitysAsync()
                   where userIds.Contains(evaluator.UserId)
                   select evaluator;
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
}