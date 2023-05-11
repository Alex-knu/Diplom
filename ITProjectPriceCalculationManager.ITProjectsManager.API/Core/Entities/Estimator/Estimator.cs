using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Estimator
{
    internal class Estimator : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? DepartmentId { get; set; }

        public Department.Department Department { get; set; }
        public ICollection<ApplicationToEstimators.ApplicationToEstimators> ApplicationToEstimators { get; set; }
        public ICollection<Profile.Profile> Profiles { get; set; }
        public ICollection<Application.Application> Applications { get; set; }
        public ICollection<EvaluatorToEvaluatedFactor.EvaluatorToEvaluatedFactor> EvaluatorToEvaluatedFactor { get; set; }
    }
}