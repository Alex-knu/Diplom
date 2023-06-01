using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.EvaluatorToEvaluatedFactor
{
    internal class EvaluatorToEvaluatedFactor : IBaseEntity<int>
    {
        public int Id { get; set; }
        public int EvaluatorId { get; set; }
        public int EvaluatedFactorId { get; set; }

        public Estimator.Estimator Evaluator { get; set; }
        public ApplicationToFactors.ApplicationToFactors EvaluatedFactor { get; set; }
    }
}