using Ardalis.Specification;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Evaluator
{
    internal class Evaluators
    {
        internal class GetEstimatorByUserId : Specification<Evaluator>
        {
            public GetEstimatorByUserId(Guid userId)
            {
                Query.Where(x => x.UserId == userId);
            }
        }
    }
}