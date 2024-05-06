using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.ParameterValue;

internal class ParameterValue : IBaseEntity<Guid>
{
    public float A { get; set; }
    public float B { get; set; }
    public float C { get; set; }
    public float D { get; set; }
    public Guid Id { get; set; }

    public Parameters.Parameters Parameter { get; set; }
}