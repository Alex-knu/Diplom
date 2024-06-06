using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.Parameters;

internal class Parameters : IBaseEntity<Guid>
{
    public Guid ApplicationId { get; set; }
    public string Name { get; set; }
    public Guid Id { get; set; }
    
    public virtual ICollection<EvaluateParameter.EvaluateParameter> EvaluateParameters { get; set; }
}