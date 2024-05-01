using Ardalis.Specification;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.DifficultyLevelsTypeToFactorType;

internal class DifficultyLevelsTypeToFactorTypes
{
    internal class DepartmentsTree : Specification<DifficultyLevelsTypeToFactorType>
    {
        public DepartmentsTree()
        {
            Query
                .Include(x => x.FactorType)
                .Include(x => x.Factor)
                .Include(x => x.DifficultyLevel);
        }
    }
}