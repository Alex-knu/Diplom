using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.DifficultyLevels;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.EvaluationAttributes;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Repositories;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services
{
    internal class EvaluationParametrsInfoService : IEvaluationParametrsInfoService
    {
        protected readonly IRepository<EvaluationAttribute, Guid> _evaluationAttributeRepository;
        protected readonly IRepository<DifficultyLevel, Guid> _difficultyLevelRepository;
        protected readonly IMapper _mapper;
        private readonly ITProjectPriceCalculationManagerDbContext _dbContext;

        public EvaluationParametrsInfoService(ITProjectPriceCalculationManagerDbContext dbContext, IRepository<EvaluationAttribute, Guid> evaluationAttributeRepository, IRepository<DifficultyLevel, Guid> difficultyLevelRepository, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _evaluationAttributeRepository = evaluationAttributeRepository;
            _difficultyLevelRepository = difficultyLevelRepository;

        }

        public async Task<IEnumerable<EvaluationParametrsInfoDTO>> GetEvaluationAttributes()
        {
            var evaluationAttributes = await _evaluationAttributeRepository.ExecuteStoredProcedure($"EXEC dbo.GetEvaluationAttributes");

            foreach(var evaluationAttribute in evaluationAttributes)
            {
                evaluationAttribute.DifficultyLevels = await _difficultyLevelRepository.ExecuteStoredProcedure($"EXEC dbo.GetDifficultyLevel {evaluationAttribute.FactorId}");
            }

            return _mapper.Map<List<EvaluationParametrsInfoDTO>>(evaluationAttributes);
        }
    }
}