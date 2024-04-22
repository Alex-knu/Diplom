using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.DifficultyLevels;

internal class DifficultyLevel : IBaseEntity<Guid>
{
    public Guid EvaluationAttributeId { get; set; }
    public Guid RelationId { get; set; }
    public string Name { get; set; }
    public Guid Id { get; set; }
}