using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.DifficultyLevelsType
{
    internal class DifficultyLevelsType : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ApplicationToFactors.ApplicationToFactors> ApplicationToFactors { get; set; }
        public virtual ICollection<DifficultyLevelsTypeToFactorType.DifficultyLevelsTypeToFactorType> DifficultyLevelsTypeToFactorTypes { get; set; }
    }
}