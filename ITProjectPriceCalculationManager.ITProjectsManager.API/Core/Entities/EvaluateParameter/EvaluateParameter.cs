using ITProjectPriceCalculationManager.Infrastructure.Interfaces;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Parameter;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.EvaluateParameter;

internal class EvaluateParameter : IBaseEntity<Guid>
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public Guid BelongingFunctionId { get; set; }
    public Guid ParameterId { get; set; }
    public Guid ParameterValueId { get; set; }
    

    public Parameter.Parameter? Parameter { get; set;  }
    public ParameterValue.ParameterValue? EvaluateParameterValue { get; set; }
    public BelongingFunction.BelongingFunction? BelongingFunction { get; set; }
}