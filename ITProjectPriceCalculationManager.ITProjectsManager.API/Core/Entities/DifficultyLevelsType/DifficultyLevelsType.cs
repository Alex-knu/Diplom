using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.DifficultyLevelsType;

internal class DifficultyLevelsType : IBaseEntity<Guid>
{
    public string Name { get; set; }

    public virtual ICollection<DifficultyLevelsTypeToFactorType.DifficultyLevelsTypeToFactorType>
        DifficultyLevelsTypeToFactorTypes { get; set; }

    public Guid Id { get; set; }
}