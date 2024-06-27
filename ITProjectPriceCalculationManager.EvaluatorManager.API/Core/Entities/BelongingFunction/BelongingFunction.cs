using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.BelongingFunction;

internal class BelongingFunction : IBaseEntity<Guid>
{
    public required string Name { get; set; }
    public Guid Id { get; set; }

    public virtual ICollection<EvaluateParameter.EvaluateParameter> EvaluateParameters{ get; set; } 
}