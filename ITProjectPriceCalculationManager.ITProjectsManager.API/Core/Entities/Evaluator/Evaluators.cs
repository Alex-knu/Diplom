using Ardalis.Specification;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Evaluator;

internal class Evaluators
{
    internal class GetEvaluatorByUserId : Specification<Evaluator>
    {
        public GetEvaluatorByUserId(Guid userId)
        {
            Query.Where(x => x.UserId == userId);
        }
    }

    internal class GetEvaluatorsWithDependencies : Specification<Evaluator>
    {
        public GetEvaluatorsWithDependencies()
        {
            Query.Include(x => x.Department);
        }
    }
}