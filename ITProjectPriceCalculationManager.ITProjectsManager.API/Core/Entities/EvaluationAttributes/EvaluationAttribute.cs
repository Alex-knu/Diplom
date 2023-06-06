using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.DifficultyLevels;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.EvaluationAttributes
{
    internal class EvaluationAttribute : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid FactorId { get; set; }
        public Guid FactorTypeId { get; set; }
        public string Name { get; set; }
        public List<DifficultyLevel> DifficultyLevels { get; set; }
    }
}