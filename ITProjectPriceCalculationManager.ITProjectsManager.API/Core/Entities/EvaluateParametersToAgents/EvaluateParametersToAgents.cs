using ITProjectPriceCalculationManager.Infrastructure.Interfaces;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Parameter;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.EvaluateParametersToAgents;

internal class EvaluateParametersToAgents : IBaseEntity<Guid>
{
    public Guid Id { get; set; }
    public Guid AgentId { get; set; }
    public Guid ParameterId { get; set; }
    public double Value { get; set; }
    

    public Parameter.Parameter? Parameter { get; set;  }
    public Evaluator.Evaluator? Agent { get; set; }
}