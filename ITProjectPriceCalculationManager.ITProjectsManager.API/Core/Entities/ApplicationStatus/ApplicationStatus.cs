using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationStatus
{
    internal class ApplicationStatus : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Application.Application> Applications{ get; set; } 
    }
}