using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.EvaluateParameterValue;

internal class EvaluateParameterValue : IBaseEntity<Guid>
{
    public float A { get; set; }
    public float B { get; set; }
    public float C { get; set; }
    public float D { get; set; }
    public Guid Id { get; set; }

    //public virtual ICollection<Application.Application> Applications{ get; set; } 
}