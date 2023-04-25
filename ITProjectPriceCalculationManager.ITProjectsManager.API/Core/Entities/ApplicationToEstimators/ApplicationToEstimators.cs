using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationToEstimators
{
    internal class ApplicationToEstimators : IBaseEntity<int>
    {
        public int Id { get; set; }
        public int  ApplicationId { get; set; }
        public int  EstimatorId { get; set; }
        public double Coeficient { get; set; }

        public Application.Application Application { get; set; }
        public Estimator.Estimator Estimator { get; set; }
    }
}