using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.EvaluateParameter;

internal class EvaluateParameter : IBaseEntity<Guid>
{
    public string Name { get; set; }
    public Guid BelongingFunctionId { get; set; }
    public Guid Id { get; set; }
    public Guid ParameterId { get; set; }
    public Guid ParameterValueId { get; set; }
    

    public Parameters.Parameters Parameter { get; set;  }
    public ParameterValue.ParameterValue ParameterValue { get; set; }
    public BelongingFunction.BelongingFunction BelongingFunction { get; set; }
}