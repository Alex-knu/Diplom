using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Estimator;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Repositories;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services
{
    internal class EvaluatorService : BaseService<Estimator, int, EvaluatorDTO>, IEvaluatorService
    {
        public EvaluatorService(IRepository<Estimator, int> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<EvaluatorDTO> CreateEvaluatorAsync(EvaluatorDTO evaluator)
        {
            return await base.CreateEntityAsync(evaluator);
        }

        public async Task<EvaluatorDTO> DeleteEvaluatorAsync(int id)
        {
            return await base.DeleteEntityAsync(id);
        }

        public async Task<IEnumerable<EvaluatorDTO>> GetEvaluatorsAsync()
        {
            return await base.GetEntitysAsync();
        }

        public async Task<EvaluatorDTO> GetEvaluatorsByIdAsync(int id)
        {
            return await base.GetEntitysByIdAsync(id);
        }

        public async Task<EvaluatorDTO> UpdateEvaluatorAsync(EvaluatorDTO evaluator)
        {
            return await base.UpdateEntityAsync(evaluator);
        }
    }
}