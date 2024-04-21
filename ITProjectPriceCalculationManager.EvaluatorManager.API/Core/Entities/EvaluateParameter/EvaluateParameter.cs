using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.EvaluateParameter
{
    internal class EvaluateParameter : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ApplicationId { get; set; }
        public Guid BelongingFunctionId { get; set; }
        public Guid ParameterId { get; set; }

        //public virtual ICollection<Application.Application> Applications{ get; set; } 
    }
}