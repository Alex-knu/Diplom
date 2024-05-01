using Ardalis.Specification;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Department;

internal class Departments
{
    internal class DepartmentsTree : Specification<Department>
    {
        public DepartmentsTree()
        {
            Query
                .Include(x => x.SubDepartments)
                .Where(x => x.ParentId == null);
        }
    }

    internal class GetDepartmentById : Specification<Department>
    {
        public GetDepartmentById(Guid id)
        {
            Query
                .Include(x => x.Parent)
                .Where(x => x.Id == id);
        }
    }
}