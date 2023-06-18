using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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