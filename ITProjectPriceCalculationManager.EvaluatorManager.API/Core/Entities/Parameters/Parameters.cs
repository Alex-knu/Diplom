using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.Parameters
{
    internal class Parameters : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        //public virtual ICollection<Application.Application> Applications{ get; set; } 
    }
}