using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.DifficultyLevelsType;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services
{
    internal class DifficultyLevelsTypeService : IDifficultyLevelsTypeService
    {
        private readonly ITProjectPriceCalculationManagerDbContext _dbContext;
        protected readonly IMapper _mapper;

        public DifficultyLevelsTypeService(ITProjectPriceCalculationManagerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<DifficultyLevelsTypeDTO> GetDifficultyLevelTypesForFactorType()
        {
            return _mapper.Map<List<DifficultyLevelsTypeDTO>>(_dbContext.GetDifficultyLevelTypesForFactorType(1));
        }
    }
}