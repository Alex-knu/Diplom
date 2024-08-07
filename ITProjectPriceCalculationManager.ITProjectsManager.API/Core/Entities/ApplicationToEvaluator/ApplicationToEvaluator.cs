using ITProjectPriceCalculationManager.Infrastructure.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationToEvaluator;

internal class ApplicationToEvaluator : IBaseEntity<Guid>
{
    public Guid Id { get; set; }
    public Guid ApplicationId { get; set; }
    public Guid EvaluatorId { get; set; }
    public double? SelfEvaluation { get; set; }
    public double? ConfidenceArea { get; set; }

    public Application.Application? Application { get; set; }
    public Evaluator.Evaluator? Evaluator { get; set; }
}