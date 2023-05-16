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

        public Task<EvaluatorDTO> CreateEvaluatorAsync(EvaluatorDTO evaluator)
        {
            return base.CreateEntityAsync(evaluator);
        }

        public Task<EvaluatorDTO> DeleteEvaluatorAsync(int id)
        {
            return base.DeleteEntityAsync(id);
        }

        public Task<IEnumerable<EvaluatorDTO>> GetEvaluatorsAsync()
        {
            return base.GetEntitysAsync();
        }

        public Task<EvaluatorDTO> GetEvaluatorsByIdAsync(int id)
        {
            return base.GetEntitysByIdAsync(id);
        }

        public Task<EvaluatorDTO> UpdateEvaluatorAsync(EvaluatorDTO evaluator)
        {
            return base.UpdateEntityAsync(evaluator);
        }
    }
}