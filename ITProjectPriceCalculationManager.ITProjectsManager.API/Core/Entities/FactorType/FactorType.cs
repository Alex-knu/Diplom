using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.FactorType;

internal class FactorType : IBaseEntity<Guid>
{
    public string Name { get; set; }

    public virtual ICollection<DifficultyLevelsTypeToFactorType.DifficultyLevelsTypeToFactorType>
        DifficultyLevelsTypeToFactorTypes { get; set; }

    public Guid Id { get; set; }
}