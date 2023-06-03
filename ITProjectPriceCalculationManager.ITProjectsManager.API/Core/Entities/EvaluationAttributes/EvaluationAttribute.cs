using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.DifficultyLevels;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.EvaluationAttributes
{
    internal class EvaluationAttribute : IBaseEntity<int>
    {
        public int Id { get; set; }
        public int FactorId { get; set; }
        public int FactorTypeId { get; set; }
        public string Name { get; set; }
        public List<DifficultyLevel> DifficultyLevels { get; set; }
    }
}