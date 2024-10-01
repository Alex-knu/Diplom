using ITProjectPriceCalculationManager.Infrastructure.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.BelongingFunction;

internal class BelongingFunction : IBaseEntity<Guid>
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    
    public virtual ICollection<EvaluateParameter.EvaluateParameter>? EvaluateParameters{ get; set; } 
}