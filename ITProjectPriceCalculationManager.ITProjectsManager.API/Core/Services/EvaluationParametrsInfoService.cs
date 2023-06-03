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
        protected readonly IRepository<EvaluationAttribute, int> _evaluationAttributeRepository;
        protected readonly IRepository<DifficultyLevel, int> _difficultyLevelRepository;
        protected readonly IMapper _mapper;
        private readonly ITProjectPriceCalculationManagerDbContext _dbContext;

        public EvaluationParametrsInfoService(ITProjectPriceCalculationManagerDbContext dbContext, IRepository<EvaluationAttribute, int> evaluationAttributeRepository, IRepository<DifficultyLevel, int> difficultyLevelRepository, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _evaluationAttributeRepository = evaluationAttributeRepository;
            _difficultyLevelRepository = difficultyLevelRepository;

        }

        public IEnumerable<EvaluationParametrsInfoDTO> GetEvaluationAttributes()
        {
            var evaluationAttributes = _evaluationAttributeRepository.ExecuteFunction("GetEvaluationAttributes", "");

            Console.WriteLine("HAHAHA");

            foreach(var evaluationAttribute in evaluationAttributes)
            {
                evaluationAttribute.DifficultyLevels = _difficultyLevelRepository.ExecuteFunction("GetDifficultyLevel", evaluationAttribute.FactorId).ToList();
            }

            return _mapper.Map<List<EvaluationParametrsInfoDTO>>(evaluationAttributes);
        }
    }
}