using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationToEstimators;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Repositories;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services
{
    internal class ApplicationToEstimatorsService : BaseService<ApplicationToEstimators, int, ApplicationToEstimatorsDTO>, IApplicationToEstimatorsService
    {
        public ApplicationToEstimatorsService(IRepository<ApplicationToEstimators, int> repository, IMapper mapper) : base(repository, mapper)
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
                    await _repository.AddAsync(new ApplicationToEstimators()
                    {
                        ApplicationId = applicationToEstimators.ApplicationId,
                        EstimatorId = evaluator.Id
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