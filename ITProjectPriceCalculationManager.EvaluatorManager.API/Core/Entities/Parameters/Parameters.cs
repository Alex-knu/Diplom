using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.Parameters;

internal class Parameters : IBaseEntity<Guid>
{
    public Guid ApplicationId { get; set; }
    public string Name { get; set; }
    public Guid Id { get; set; }

    public Guid ParameterValueId { get; set; }

    public ParameterValue.ParameterValue ParameterValue { get; set; }
    public EvaluateParameter.EvaluateParameter EvaluateParameter { get; set; }
}