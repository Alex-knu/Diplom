using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.BelongingFunction;

internal class BelongingFunction : IBaseEntity<Guid>
{
    public string Name { get; set; }
    public Guid Id { get; set; }

    //public virtual ICollection<Application.Application> Applications{ get; set; } 
}