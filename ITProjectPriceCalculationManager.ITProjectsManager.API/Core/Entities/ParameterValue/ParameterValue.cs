using ITProjectPriceCalculationManager.Infrastructure.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ParameterValue;

internal class ParameterValue : IBaseEntity<Guid>
{
    public Guid Id { get; set; }
    public float A { get; set; }
    public float B { get; set; }
    public float C { get; set; }
    public float D { get; set; }

    public EvaluateParameter.EvaluateParameter? EvaluateParameter { get; set; }
}