using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services
{
    internal class EvaluationParametrsInfoService : IEvaluationParametrsInfoService
    {
        private readonly ITProjectPriceCalculationManagerDbContext _dbContext;

        public EvaluationParametrsInfoService(ITProjectPriceCalculationManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<EvaluationParametrsInfoDTO> GetEvaluationAttributes()
        {
            return _dbContext.GetEvaluationAttributes().DistinctBy(info => info.Name).ToList();
        }
    }
}