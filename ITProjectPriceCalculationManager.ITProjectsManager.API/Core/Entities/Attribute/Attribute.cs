using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Attribute;

internal class Attribute : IBaseEntity<Guid>
{
    public string Name { get; set; }

    public virtual ICollection<Profile.Profile> Profiles { get; set; }

    public virtual ICollection<DifficultyLevelsTypeToFactorType.DifficultyLevelsTypeToFactorType>
        DifficultyLevelsTypeToFactorTypes { get; set; }

    public Guid Id { get; set; }
}