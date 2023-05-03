using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Profile
{
    internal class Profile : IBaseEntity<int>
    {
        public int Id { get; set; }
        public int AttributeId { get; set; }
        public int EstimatorId { get; set; }
        public string Value { get; set; }

        public Attribute.Attribute Attribute { get; set; }
        public Estimator.Estimator Estimator { get; set; }
    }
}