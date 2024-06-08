using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationToEvaluator;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Evaluator;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Repositories;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services;

internal class ApplicationToEstimatorsService : BaseService<ApplicationToEvaluator, Guid, ApplicationToEstimatorsDTO>,
    IApplicationToEstimatorsService
{
    private readonly IRepository<Evaluator, Guid> _evaluatorRepository;
    
    public ApplicationToEstimatorsService(IRepository<Evaluator, Guid> evaluatorRepository, IRepository<ApplicationToEvaluator, Guid> repository, IMapper mapper) : base(
        repository, mapper)
    {
        _evaluatorRepository = evaluatorRepository;
    }

    public async Task<IEnumerable<EvaluatorDTO>> GetEstimatorGroupByApplicationId(Guid applicationId)
    {
        return (from applicationToEstimators in await _repository.GetAllAsync()
                join evaluator in await _evaluatorRepository.GetAllAsync() on applicationToEstimators.EvaluatorId equals evaluator.Id
                where applicationToEstimators.ApplicationId == applicationId
                select new EvaluatorDTO()
                {
                    Id = evaluator.Id,
                    UserId = evaluator.UserId,
                    DepartmentId = evaluator.DepartmentId,
                    FirstName = evaluator.FirstName,
                    LastName = evaluator.LastName,
                    CompetencyLevel = applicationToEstimators.CompetencyLevel
                });
    }

    public async Task<ApplicationToEstimatorsDTO> CreateApplicationToEstimatorsAsync(
        ApplicationToEstimatorsDTO applicationToEstimators)
    {
        return await CreateEntityAsync(applicationToEstimators);
    }

    protected override async Task<ApplicationToEstimatorsDTO> CreateEntityAsync(
        ApplicationToEstimatorsDTO applicationToEstimators)
    {
        try
        {
            foreach (var evaluator in applicationToEstimators.Evaluators)
                await _repository.AddAsync(new ApplicationToEvaluator
                {
                    ApplicationId = applicationToEstimators.ApplicationId,
                    EvaluatorId = evaluator.Id
                });

            await _repository.SaveChangesAcync();

            return applicationToEstimators;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}