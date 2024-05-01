using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Profile;

internal class Profile : IBaseEntity<Guid>
{
    public Guid AttributeId { get; set; }
    public Guid EvaluatorId { get; set; }
    public string Value { get; set; }

    public Attribute.Attribute Attribute { get; set; }
    public Evaluator.Evaluator Evaluator { get; set; }
    public Guid Id { get; set; }
}