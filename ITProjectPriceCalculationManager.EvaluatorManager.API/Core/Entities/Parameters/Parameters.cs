using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.Parameters;

internal class Parameters : IBaseEntity<Guid>
{
    public Guid Id { get; set; }
    public Guid ApplicationId { get; set; }
    public required string Name { get; set; }
    
    public virtual ICollection<EvaluateParameter.EvaluateParameter> EvaluateParameters { get; set; }
}