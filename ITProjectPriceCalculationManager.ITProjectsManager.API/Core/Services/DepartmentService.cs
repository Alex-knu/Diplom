using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Department;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Repositories;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services
{
    internal class DepartmentService : BaseService<Department, int, DepartmentDTO>, IDepartmentService
    {
        public DepartmentService(IRepository<Department, int> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public Task<DepartmentDTO> CreateDepartmentAsync(DepartmentDTO department)
        {
            return base.CreateEntityAsync(department);
        }

        public Task<DepartmentDTO> DeleteDepartmentAsync(int id)
        {
            return base.DeleteEntityAsync(id);
        }

        public Task<IEnumerable<DepartmentDTO>> GetDepartmentsTreeAsync()
        {
            return base.GetEntityListBySpecAsync(new Departments.DepartmentsTree());
        }

        public Task<IEnumerable<DepartmentDTO>> GetDepartmentsAsync()
        {
            return base.GetEntitysAsync();
        }

        public Task<DepartmentDTO> GetDepartmentsByIdAsync(int id)
        {
            return base.GetEntitysByIdAsync(id);
        }

        public Task<DepartmentDTO> UpdateDepartmentAsync(DepartmentDTO department)
        {
            return base.UpdateEntityAsync(department);
        }
    }
}