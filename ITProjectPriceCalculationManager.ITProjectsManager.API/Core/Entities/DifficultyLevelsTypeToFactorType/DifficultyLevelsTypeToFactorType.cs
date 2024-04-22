using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.DifficultyLevelsTypeToFactorType;

internal class DifficultyLevelsTypeToFactorType : IBaseEntity<Guid>
{
    public Guid DifficultyLevelId { get; set; }
    public Guid FactorId { get; set; }
    public Guid FactorTypeId { get; set; }
    public double Value { get; set; }

    public DifficultyLevelsType.DifficultyLevelsType DifficultyLevel { get; set; }
    public Attribute.Attribute Factor { get; set; }
    public FactorType.FactorType FactorType { get; set; }
    public virtual ICollection<ApplicationToFactor.ApplicationToFactor> ApplicationToFactors { get; set; }
    public Guid Id { get; set; }
}