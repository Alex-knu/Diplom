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

        public async Task<DepartmentDTO> CreateDepartmentAsync(DepartmentDTO department)
        {
            return await base.CreateEntityAsync(department);
        }

        public async Task<DepartmentDTO> DeleteDepartmentAsync(int id)
        {
            return await base.DeleteEntityAsync(id);
        }

        public async Task<IEnumerable<DepartmentDTO>> GetDepartmentsTreeAsync()
        {
            return await base.GetEntityListBySpecAsync(new Departments.DepartmentsTree());
        }

        public async Task<IEnumerable<DepartmentDTO>> GetDepartmentsAsync()
        {
            return await base.GetEntitysAsync();
        }

        public async Task<DepartmentDTO> GetDepartmentsByIdAsync(int id)
        {
            return await base.GetEntitysByIdAsync(id);
        }

        public async Task<DepartmentDTO> UpdateDepartmentAsync(DepartmentDTO department)
        {
            return await base.UpdateEntityAsync(department);
        }
    }
}