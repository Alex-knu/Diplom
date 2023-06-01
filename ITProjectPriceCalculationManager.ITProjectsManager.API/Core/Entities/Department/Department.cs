using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Department
{
    internal class Department : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public Department Parent { get; set; }
        public ICollection<Department> SubDepartments { get; set; }
        public ICollection<Estimator.Estimator> Estimators { get; set; }
    }
}