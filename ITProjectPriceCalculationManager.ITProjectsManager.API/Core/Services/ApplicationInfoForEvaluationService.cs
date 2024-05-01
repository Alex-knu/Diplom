using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.DTOModels.Enums;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationForEvaluation;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationToFactor;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.DifficultyLevels;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramsParametr;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Repositories;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services;

internal class ApplicationInfoForEvaluationService : IApplicationInfoForEvaluationService
{
    protected readonly IRepository<ApplicationForEvaluation, Guid> _applicationForEvaluationRepository;
    protected readonly IRepository<ApplicationToFactor, Guid> _applicationToFactorRepository;
    private readonly ITProjectPriceCalculationManagerDbContext _dbContext;
    protected readonly IRepository<DifficultyLevel, Guid> _difficultyLevelRepository;
    protected readonly IMapper _mapper;
    protected readonly IRepository<ProgramsParametr, Guid> _programsParametrRepository;

    public ApplicationInfoForEvaluationService(
        ITProjectPriceCalculationManagerDbContext dbContext,
        IRepository<ApplicationForEvaluation, Guid> applicationForEvaluationRepository,
        IRepository<ApplicationToFactor, Guid> applicationToFactorRepository,
        IRepository<DifficultyLevel, Guid> difficultyLevelRepository,
        IRepository<ProgramsParametr, Guid> programsParametrRepository,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _applicationToFactorRepository = applicationToFactorRepository;
        _difficultyLevelRepository = difficultyLevelRepository;
        _applicationForEvaluationRepository = applicationForEvaluationRepository;
        _programsParametrRepository = programsParametrRepository;
    }

    public async Task<EvaluationDTO> GetForEvaluation(Guid applicationId)
    {
        var applicationForEvaluation = _mapper.Map<EvaluationDTO>(
            (await _applicationForEvaluationRepository.ExecuteStoredProcedure(
                $"EXEC dbo.GetApplicationsByIdForEvaluation {applicationId}")).FirstOrDefault());

        var t = (from ft in _dbContext.FactorTypes
            select ft).ToList();

        applicationForEvaluation.EvaluationFactors = (from af in _dbContext.ApplicationToFactors
            join dltft in _dbContext.DifficultyLevelsTypeToFactorTypes on af.DifficultyLevelsTypeToFactorTypeId equals
                dltft.Id
            where af.ApplicationId == applicationId
            select new EvaluationFactorDTO
            {
                Id = af.Id,
                Count = (int?)af.Value,
                Value = dltft.Value,
                SelfEvaluation = 0,
                FactorId = dltft.FactorId,
                FactorType = (from ft in _dbContext.FactorTypes
                    where ft.Id == dltft.FactorTypeId
                    select ft).First().Id == new Guid("B03771E5-488A-449F-B886-19C581B63CDE")
                    ? FactorType.InfluenceFactors
                    : FactorType.ScaleFactors
            }).ToList();

        applicationForEvaluation.ProgramsParametrEvaluationFactor =
            _mapper.Map<List<ProgramsParametrEvaluationFactorDTO>>(
                await _programsParametrRepository.GetListBySpecAsync(
                    new ProgramsParametrs.ProgramsParametrsByApplicationId(applicationId)));

        applicationForEvaluation.ProgramsParametrEvaluationFactor
            .ForEach(ppef => ppef.SubjectAreaElements = (from pp in _dbContext.ProgramsParametrs
                join pptsae in _dbContext.ProgramsParametrToSubjectAreaElements on pp.Id equals pptsae
                    .ProgramsParametrId
                join af in _dbContext.ApplicationToFactors on pptsae.SubjectAreaElementId equals af.Id
                join dltft in _dbContext.DifficultyLevelsTypeToFactorTypes on af.DifficultyLevelsTypeToFactorTypeId
                    equals dltft.Id
                where pp.ApplicationId == applicationId && pp.ProgramLanguageId == ppef.Id
                select new EvaluationFactorDTO
                {
                    Id = af.Id,
                    Count = (int?)af.Value,
                    Value = dltft.Value,
                    SelfEvaluation = 0,
                    FactorId = dltft.FactorId,
                    FactorType = (from ft in _dbContext.FactorTypes
                        where ft.Id == dltft.FactorTypeId
                        select ft).First().Id == new Guid("CDD64D87-BB9A-4C17-B809-05C4454E6998")
                        ? FactorType.InformationObject
                        : FactorType.Function
                }).ToList());

        return applicationForEvaluation;
    }
}