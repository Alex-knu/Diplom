using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationToFactors;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Evaluator;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.EvaluatorToEvaluatedFactor;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramsParametrToSubjectAreaElement;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Repositories;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services
{
    internal class ApplicationToFactorsService : BaseService<ApplicationToFactors, Guid, EvaluationApplicationDTO>, IApplicationToFactorsService
    {
        protected readonly IRepository<EvaluatorToEvaluatedFactor, Guid> _evaluatorToEvaluatedFactorRepository;
        protected readonly IRepository<ProgramsParametrToSubjectAreaElement, Guid> _programsParametrToSubjectAreaElementRepository;
        protected readonly IRepository<Evaluator, Guid> _estimatorRepository;

        public ApplicationToFactorsService(IRepository<EvaluatorToEvaluatedFactor, Guid> evaluatorToEvaluatedFactorRepository, IRepository<ProgramsParametrToSubjectAreaElement, Guid> programsParametrToSubjectAreaElementRepository, IRepository<Evaluator, Guid> estimatorRepository, IRepository<ApplicationToFactors, Guid> repository, IMapper mapper) : base(repository, mapper)
        {
            _evaluatorToEvaluatedFactorRepository = evaluatorToEvaluatedFactorRepository;
            _estimatorRepository = estimatorRepository;
            _programsParametrToSubjectAreaElementRepository = programsParametrToSubjectAreaElementRepository;
        }

        public async Task<EvaluationApplicationDTO> CreateApplicationToFactorsAsync(EvaluationApplicationDTO evaluationApplication)
        {
            return await CreateEntityAsync(evaluationApplication);
        }

        protected override async Task<EvaluationApplicationDTO> CreateEntityAsync(EvaluationApplicationDTO evaluationApplication)
        {
            try
            {
                var domainCreator = await _estimatorRepository.GetFirstBySpecAsync(new Evaluators.GetEvaluatorByUserId(evaluationApplication.UserCreatorId));

                if (domainCreator == null)
                {
                    throw new BadHttpRequestException("Creator not found");
                }

                var newDomainApplicationToFactors = await _repository.AddRangeAsync(_mapper.Map<List<ApplicationToFactors>>(evaluationApplication.ApplicationToFactors));
                await _repository.SaveChangesAcync();

                foreach (var program in evaluationApplication.ProgramInfo)
                {
                    var newDomainApplicationToFactorsForProgram = await _repository.AddRangeAsync(_mapper.Map<List<ApplicationToFactors>>(program.ApplicationToFactors));
                    await _repository.SaveChangesAcync();

                    await _evaluatorToEvaluatedFactorRepository.AddRangeAsync((from atf in newDomainApplicationToFactorsForProgram
                                                                               select new EvaluatorToEvaluatedFactor
                                                                               {
                                                                                   EvaluatorId = domainCreator.Id,
                                                                                   EvaluatedFactorId = atf.Id
                                                                               }).ToList());

                    await _programsParametrToSubjectAreaElementRepository.AddRangeAsync((from atf in newDomainApplicationToFactorsForProgram
                                                                                         select new ProgramsParametrToSubjectAreaElement
                                                                                         {
                                                                                             ProgramsParametrId = program.Id,
                                                                                             SubjectAreaElementId = atf.Id
                                                                                         }).ToList());
                }


                await _evaluatorToEvaluatedFactorRepository.AddRangeAsync((from atf in newDomainApplicationToFactors
                                                                           select new EvaluatorToEvaluatedFactor
                                                                           {
                                                                               EvaluatorId = domainCreator.Id,
                                                                               EvaluatedFactorId = atf.Id
                                                                           }).ToList());

                await _evaluatorToEvaluatedFactorRepository.SaveChangesAcync();
                await _programsParametrToSubjectAreaElementRepository.SaveChangesAcync();

                return evaluationApplication;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}