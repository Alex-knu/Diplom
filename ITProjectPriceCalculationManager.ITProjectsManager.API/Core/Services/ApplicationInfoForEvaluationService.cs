using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.DTOModels.Enums;
using ITProjectPriceCalculationManager.Infrastructure.Interfaces;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationForEvaluation;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services;

internal class ApplicationInfoForEvaluationService : IApplicationInfoForEvaluationService
{
    protected readonly IRepository<ApplicationForEvaluation, Guid, ITProjectPriceCalculationManagerDbContext> _applicationForEvaluationRepository;
    private readonly ITProjectPriceCalculationManagerDbContext _dbContext;
    protected readonly IMapper _mapper;

    public ApplicationInfoForEvaluationService(
        ITProjectPriceCalculationManagerDbContext dbContext,
        IRepository<ApplicationForEvaluation, Guid, ITProjectPriceCalculationManagerDbContext> applicationForEvaluationRepository,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _applicationForEvaluationRepository = applicationForEvaluationRepository;
    }

    public async Task<EvaluationDTO> GetForEvaluation(Guid applicationId)
    {
        var applicationForEvaluation = _mapper.Map<EvaluationDTO>(
            (await _applicationForEvaluationRepository.ExecuteStoredProcedure(
                $"EXEC dbo.GetApplicationsByIdForEvaluation {applicationId}")).FirstOrDefault());

        return applicationForEvaluation;
    }
}