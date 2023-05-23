using Ardalis.Specification;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Estimator
{
    internal class Estimators
    {
        internal class GetEstimatorByUserId : Specification<Estimator>
        {
            public GetEstimatorByUserId(string userId)
            {
                Query.Where(x => x.UserId == userId);
            }
        }
    }
}