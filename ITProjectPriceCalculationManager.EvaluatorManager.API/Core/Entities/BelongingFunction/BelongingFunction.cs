using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.BelongingFunction
{
    internal class BelongingFunction : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        //public virtual ICollection<Application.Application> Applications{ get; set; } 
    }
}