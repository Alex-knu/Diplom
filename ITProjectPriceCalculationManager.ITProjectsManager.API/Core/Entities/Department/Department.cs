using ITProjectPriceCalculationManager.Infrastructure.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Department;

internal class Department : IBaseEntity<Guid>
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public Guid? ParentId { get; set; }

    public Department? Parent { get; set; }
    
    public ICollection<Department>? SubDepartments { get; set; }
    public ICollection<Evaluator.Evaluator>? Evaluators { get; set; }
}