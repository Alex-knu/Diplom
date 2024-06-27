using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Evaluator;

internal class Evaluator : IBaseEntity<Guid>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Phone { get; set; }
    public required string Email { get; set; }
    public Guid? DepartmentId { get; set; }

    public Department.Department? Department { get; set; }
    public required ICollection<ApplicationToEvaluator.ApplicationToEvaluator> ApplicationToEvaluators { get; set; }
    public required ICollection<Profile.Profile> Profiles { get; set; }
    public required ICollection<Application.Application> Applications { get; set; }
    public required ICollection<EvaluatorToEvaluatedFactor.EvaluatorToEvaluatedFactor> EvaluatorToEvaluatedFactor { get; set; }
}