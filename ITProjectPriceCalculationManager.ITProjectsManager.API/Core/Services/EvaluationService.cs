using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationToFactors;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Repositories;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services
{
    internal class EvaluationService : BaseService<ApplicationToFactors, int, EvaluationDTO>, IEvaluationService
    {
        public EvaluationService(IRepository<ApplicationToFactors, int> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public Task<EvaluationDTO> CreateEvaluationAsync(EvaluationDTO evaluation)
        {
            return base.CreateEntityAsync(evaluation);
        }

        public Task<EvaluationDTO> DeleteEvaluationAsync(int id)
        {
            return base.DeleteEntityAsync(id);
        }

        public Task<IEnumerable<EvaluationDTO>> GetEvaluationsAsync()
        {
            return base.GetEntitysAsync();
        }

        public Task<EvaluationDTO> GetEvaluationsByIdAsync(int id)
        {
            return base.GetEntitysByIdAsync(id);
        }

        public Task<EvaluationDTO> UpdateEvaluationAsync(EvaluationDTO evaluation)
        {
            return base.UpdateEntityAsync(evaluation);
        }
    }
}