using ITProjectPriceCalculationManager.Infrastructure.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.DifficultyLevelsType;

internal class DifficultyLevelsType : IBaseEntity<Guid>
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public virtual ICollection<DifficultyLevelsTypeToFactorType.DifficultyLevelsTypeToFactorType>? DifficultyLevelsTypeToFactorTypes { get; set; }
}