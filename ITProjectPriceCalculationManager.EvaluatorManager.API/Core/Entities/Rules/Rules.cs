using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.Rules;

internal class Rules : IBaseEntity<Guid>
{
    public Guid IfParameterId { get; set; }
    public Guid IfValueId { get; set; }
    public Guid ThenParameterId { get; set; }
    public Guid ThenValueId { get; set; }
    public Guid Id { get; set; }

    //public virtual ICollection<Application.Application> Applications{ get; set; } 
}