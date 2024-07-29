using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.EvaluateParameter;

public class EvaluateParameter : IBaseEntity<Guid>
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public Guid BelongingFunctionId { get; set; }
    public Guid ParameterId { get; set; }
    public Guid ParameterValueId { get; set; }
    

    public Parameters.Parameters? Parameter { get; set;  }
    public ParameterValue.ParameterValue? EvaluateParameterValue { get; set; }
    public BelongingFunction.BelongingFunction? BelongingFunction { get; set; }
}