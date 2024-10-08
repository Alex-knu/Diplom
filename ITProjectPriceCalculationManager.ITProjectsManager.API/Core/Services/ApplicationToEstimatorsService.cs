using AutoMapper;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationToEvaluator;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Evaluator;
using ITProjectPriceCalculationManager.Infrastructure.Interfaces;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data;
using ITProjectPriceCalculationManager.Infrastructure.Services;
using ITProjectPriceCalculationManager.DTOModels.DTO.ITProjectsManager;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services;

internal class ApplicationToEstimatorsService : BaseService<ApplicationToEvaluator, Guid, ApplicationToEstimatorsDTO, ITProjectPriceCalculationManagerDbContext>,
    IApplicationToEstimatorsService
{
    private readonly IRepository<Evaluator, Guid, ITProjectPriceCalculationManagerDbContext> _evaluatorRepository;

    public ApplicationToEstimatorsService(IRepository<Evaluator, Guid, ITProjectPriceCalculationManagerDbContext> evaluatorRepository, IRepository<ApplicationToEvaluator, Guid, ITProjectPriceCalculationManagerDbContext> repository, IMapper mapper) : base(
        repository, mapper)
    {
        _evaluatorRepository = evaluatorRepository;
    }

    public async Task<IEnumerable<EvaluatorDTO>> GetEstimatorGroupByApplicationId(Guid applicationId)
    {
        return from applicationToEstimators in await _repository.GetAllAsync()
               join evaluator in await _evaluatorRepository.GetAllAsync() on applicationToEstimators.EvaluatorId equals evaluator.Id
               where applicationToEstimators.ApplicationId == applicationId
               select new EvaluatorDTO()
               {
                   Id = evaluator.Id,
                   UserId = evaluator.UserId,
                   DepartmentId = evaluator.DepartmentId,
                   FirstName = evaluator.FirstName,
                   LastName = evaluator.LastName,
                   Phone = evaluator.Phone,
                   Email = evaluator.Email,
                   CompetencyLevel = applicationToEstimators.ConfidenceArea
               };
    }

    public async Task<ApplicationToEstimatorsDTO> CreateApplicationToEstimatorsAsync(ApplicationToEstimatorsDTO applicationToEstimators)
    {
        return await CreateEntityAsync(applicationToEstimators);
    }

    public async Task<ApplicationToEstimatorsDTO> UpdateApplicationToEstimatorsAsync(ApplicationToEstimatorsDTO applicationToEstimators)
    {
        var domainModel = (await _repository.GetAllAsync())
            .FirstOrDefault(ate => ate.ApplicationId == applicationToEstimators.ApplicationId && ate.EvaluatorId == applicationToEstimators.EvaluatorId);

        if (domainModel != null)
        {
            domainModel.ConfidenceArea = applicationToEstimators.ConfidenceArea;
            return await UpdateEntityAsync(domainModel);
        }

        return new ApplicationToEstimatorsDTO();
    }

    protected override async Task<ApplicationToEstimatorsDTO> CreateEntityAsync(ApplicationToEstimatorsDTO applicationToEstimators)
    {
        try
        {
            if (applicationToEstimators.Evaluators != null)
            {
                foreach (var evaluator in applicationToEstimators.Evaluators)
                {
                    await _repository.AddAsync(new ApplicationToEvaluator
                    {
                        ApplicationId = applicationToEstimators.ApplicationId,
                        EvaluatorId = evaluator.Id
                    });
                }
            }
            
            await _repository.SaveChangesAcync();

            return applicationToEstimators;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    async Task<ApplicationToEstimatorsDTO> UpdateEntityAsync(ApplicationToEvaluator entity)
    {
        try
        {
            var updateDomainEntity = await _repository.UpdateAsync(entity);
            await _repository.SaveChangesAcync();

            return _mapper.Map<ApplicationToEstimatorsDTO>(updateDomainEntity);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}