using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.DifficultyLevels;
using ITProjectPriceCalculationManager.Infrastructure.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.EvaluationAttributes;

internal class EvaluationAttribute : IBaseEntity<Guid>
{
    public Guid Id { get; set; }
    public Guid FactorId { get; set; }
    public Guid FactorTypeId { get; set; }
    public required string Name { get; set; }
    public required List<DifficultyLevel> DifficultyLevels { get; set; }
}