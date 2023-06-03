using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Evaluator
{
    internal class Evaluator : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Guid? DepartmentId { get; set; }

        public Department.Department Department { get; set; }
        public ICollection<ApplicationToEvaluator.ApplicationToEvaluator> ApplicationToEvaluators { get; set; }
        public ICollection<Profile.Profile> Profiles { get; set; }
        public ICollection<Application.Application> Applications { get; set; }
        public ICollection<EvaluatorToEvaluatedFactor.EvaluatorToEvaluatedFactor> EvaluatorToEvaluatedFactor { get; set; }
    }
}