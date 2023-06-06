using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationToEvaluator;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Repositories;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services
{
    internal class ApplicationToEstimatorsService : BaseService<ApplicationToEvaluator, Guid, ApplicationToEstimatorsDTO>, IApplicationToEstimatorsService
    {
        public ApplicationToEstimatorsService(IRepository<ApplicationToEvaluator, Guid> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<ApplicationToEstimatorsDTO> CreateApplicationToEstimatorsAsync(ApplicationToEstimatorsDTO applicationToEstimators)
        {
            return await CreateEntityAsync(applicationToEstimators);
        }

        protected override async Task<ApplicationToEstimatorsDTO> CreateEntityAsync(ApplicationToEstimatorsDTO applicationToEstimators)
        {
            try
            {
                foreach (var evaluator in applicationToEstimators.Evaluators)
                {
                    await _repository.AddAsync(new ApplicationToEvaluator()
                    {
                        ApplicationId = applicationToEstimators.ApplicationId,
                        EvaluatorId = evaluator.Id
                    });
                }

                await _repository.SaveChangesAcync();

                return applicationToEstimators;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}