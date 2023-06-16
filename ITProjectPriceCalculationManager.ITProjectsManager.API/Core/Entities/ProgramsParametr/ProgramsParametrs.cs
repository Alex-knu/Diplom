using Ardalis.Specification;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramsParametr
{
    internal class ProgramsParametrs
    {
        internal class ProgramsParametrsByApplicationId : Specification<ProgramsParametr>
        {
            public ProgramsParametrsByApplicationId(Guid applicationId)
            {
                Query
                    .Include(x => x.ProgramLanguage)
                    .Where(x => x.ApplicationId == applicationId);

            }
        }
    }
}