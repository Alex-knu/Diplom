using Ardalis.Specification;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationToFactor;

internal class ApplicationToFactors
{
    internal class ApplicationToFactorForEvaluation : Specification<ApplicationToFactor>
    {
        public ApplicationToFactorForEvaluation(Guid applicationId, bool valueIsContains)
        {
            if (valueIsContains)
                Query
                    .Include(x => x.DifficultyLevelsTypeToFactorType)
                    .Where(x => x.ApplicationId == applicationId && x.Value != null);
            else
            {
                Query
                    .Include(x => x.DifficultyLevelsTypeToFactorType)
                    .Where(x => x.ApplicationId == applicationId && x.Value == null);
            }
        }
    }
}