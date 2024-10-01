using ITProjectPriceCalculationManager.Infrastructure.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Parameter;

internal class Parameter : IBaseEntity<Guid>
{
    public Guid Id { get; set; }
    public Guid ApplicationId { get; set; }
    public required string Name { get; set; }
    
    public virtual Application.Application? Application { get; set; }
    public virtual EvaluateParametersToAgents.EvaluateParametersToAgents? EvaluateParametersToAgent { get; set; }
    public virtual ICollection<EvaluateParameter.EvaluateParameter>? EvaluateParameters { get; set; }
}