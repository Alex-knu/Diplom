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

        public async Task<EvaluationDTO> CreateEvaluationAsync(EvaluationDTO evaluation)
        {
            return await base.CreateEntityAsync(evaluation);
        }

        public async Task<EvaluationDTO> DeleteEvaluationAsync(int id)
        {
            return await base.DeleteEntityAsync(id);
        }

        public async Task<IEnumerable<EvaluationDTO>> GetEvaluationsAsync()
        {
            return await base.GetEntitysAsync();
        }

        public async Task<EvaluationDTO> GetEvaluationsByIdAsync(int id)
        {
            return await base.GetEntitysByIdAsync(id);
        }

        public async Task<EvaluationDTO> UpdateEvaluationAsync(EvaluationDTO evaluation)
        {
            return await base.UpdateEntityAsync(evaluation);
        }
    }
}