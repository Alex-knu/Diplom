using Ardalis.Specification;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Department
{
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
    }
}