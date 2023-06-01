using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Department;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Repositories;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services
{
    internal class DepartmentTreeService : BaseService<Department, int, DepartmentDTO>, IDepartmentTreeService
    {
        public DepartmentTreeService(IRepository<Department, int> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<IEnumerable<DepartmentDTO>> GetDepartmentsTreeAsync()
        {
            return await base.GetEntityListBySpecAsync(new Departments.DepartmentsTree());
        }
    }
}