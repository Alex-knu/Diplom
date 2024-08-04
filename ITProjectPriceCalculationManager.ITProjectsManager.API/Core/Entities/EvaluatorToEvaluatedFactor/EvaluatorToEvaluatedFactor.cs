using ITProjectPriceCalculationManager.Infrastructure.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.EvaluatorToEvaluatedFactor;

internal class EvaluatorToEvaluatedFactor : IBaseEntity<Guid>
{
    public Guid Id { get; set; }
    public Guid EvaluatorId { get; set; }
    public Guid EvaluatedFactorId { get; set; }

    public Evaluator.Evaluator? Evaluator { get; set; }
    public ApplicationToFactor.ApplicationToFactor? EvaluatedFactor { get; set; }
}