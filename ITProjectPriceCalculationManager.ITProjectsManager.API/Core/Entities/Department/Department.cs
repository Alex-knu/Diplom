using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Department;

internal class Department : IBaseEntity<Guid>
{
    public string Name { get; set; }
    public Guid? ParentId { get; set; }

    public Department? Parent { get; set; }
    public ICollection<Department> SubDepartments { get; set; }
    public ICollection<Evaluator.Evaluator> Evaluators { get; set; }
    public Guid Id { get; set; }
}