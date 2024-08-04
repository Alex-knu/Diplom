using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationToFactor;
using ITProjectPriceCalculationManager.Infrastructure.Interfaces;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data;
using ITProjectPriceCalculationManager.Infrastructure.Services;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services;

internal class EvaluationService : BaseService<ApplicationToFactor, Guid, EvaluationDTO, ITProjectPriceCalculationManagerDbContext>, IEvaluationService
{
    public EvaluationService(IRepository<ApplicationToFactor, Guid, ITProjectPriceCalculationManagerDbContext> repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<EvaluationDTO> CreateEvaluationAsync(EvaluationDTO evaluation)
    {
        return await base.CreateEntityAsync(evaluation);
    }

    public async Task<EvaluationDTO> DeleteEvaluationAsync(Guid id)
    {
        return await base.DeleteEntityAsync(id);
    }

    public async Task<IEnumerable<EvaluationDTO>> GetEvaluationsAsync()
    {
        return await base.GetEntitysAsync();
    }

    public async Task<EvaluationDTO> GetEvaluationsByIdAsync(Guid id)
    {
        return await base.GetEntitysByIdAsync(id);
    }

    public async Task<EvaluationDTO> UpdateEvaluationAsync(EvaluationDTO evaluation)
    {
        return await base.UpdateEntityAsync(evaluation);
    }
}