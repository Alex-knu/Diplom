using ITProjectPriceCalculationManager.Infrastructure.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.FactorType;

internal class FactorType : IBaseEntity<Guid>
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public virtual ICollection<DifficultyLevelsTypeToFactorType.DifficultyLevelsTypeToFactorType>? DifficultyLevelsTypeToFactorTypes { get; set; }
}