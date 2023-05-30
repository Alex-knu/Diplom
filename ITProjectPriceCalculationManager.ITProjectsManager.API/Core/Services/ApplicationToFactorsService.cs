using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationToFactors;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Estimator;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.EvaluatorToEvaluatedFactor;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Repositories;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services
{
    internal class ApplicationToFactorsService : BaseService<ApplicationToFactors, int, EvaluationApplicationDTO>, IApplicationToFactorsService
    {
        protected readonly IRepository<EvaluatorToEvaluatedFactor, int> _evaluatorToEvaluatedFactorRepository;
        protected readonly IRepository<Estimator, int> _estimatorRepository;
        public ApplicationToFactorsService(IRepository<EvaluatorToEvaluatedFactor, int> evaluatorToEvaluatedFactorRepository, IRepository<Estimator, int> estimatorRepository, IRepository<ApplicationToFactors, int> repository, IMapper mapper) : base(repository, mapper)
        {
            _evaluatorToEvaluatedFactorRepository = evaluatorToEvaluatedFactorRepository;
            _estimatorRepository = estimatorRepository;
        }

        public async Task<EvaluationApplicationDTO> CreateApplicationToFactorsAsync(EvaluationApplicationDTO evaluationApplication)
        {
            return await CreateEntityAsync(evaluationApplication);
        }

        protected override async Task<EvaluationApplicationDTO> CreateEntityAsync(EvaluationApplicationDTO evaluationApplication)
        {
            try
            {
                var domainCreator = await _estimatorRepository.GetFirstBySpecAsync(new Estimators.GetEstimatorByUserId(evaluationApplication.UserCreatorId));

                if (domainCreator == null)
                {
                    throw new BadHttpRequestException("Creator not found");
                }

                var newDomainApplicationToFactors = await _repository.AddRangeAsync(_mapper.Map<List<ApplicationToFactors>>(evaluationApplication.ApplicationToFactors));

                await _repository.SaveChangesAcync();

                var newDomainEvaluatorToEvaluatedFactor = from atf in newDomainApplicationToFactors
                                                          select new EvaluatorToEvaluatedFactor
                                                          {
                                                              EvaluatorId = domainCreator.Id,
                                                              EvaluatedFactorId = atf.Id
                                                          };

                await _evaluatorToEvaluatedFactorRepository.AddRangeAsync(newDomainEvaluatorToEvaluatedFactor.ToList());

                await _evaluatorToEvaluatedFactorRepository.SaveChangesAcync();

                return evaluationApplication;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}