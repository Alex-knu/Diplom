using ITProjectPriceCalculationManager.Infrastructure.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Profile;

internal class Profile : IBaseEntity<Guid>
{
    public Guid Id { get; set; }
    public Guid AttributeId { get; set; }
    public Guid EvaluatorId { get; set; }
    public required string Value { get; set; }

    public Attribute.Attribute? Attribute { get; set; }
    public Evaluator.Evaluator? Evaluator { get; set; }
}