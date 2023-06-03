using System.Threading.Tasks;
using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Department;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Repositories;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services
{
    internal class DepartmentService : BaseService<Department, Guid, DepartmentDTO>, IDepartmentService
    {
        public DepartmentService(IRepository<Department, Guid> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<DepartmentDTO> CreateDepartmentAsync(DepartmentDTO department)
        {
            return await base.CreateEntityAsync(department);
        }

        public async Task<DepartmentDTO> DeleteDepartmentAsync(Guid id)
        {
            return await base.DeleteEntityAsync(id);
        }

        public async Task<IEnumerable<DepartmentDTO>> GetDepartmentsAsync()
        {
            return await base.GetEntitysAsync();
        }

        public async Task<DepartmentDTO> GetDepartmentsByIdAsync(Guid id)
        {
            return await GetEntitysByIdAsync(id);
        }

        public async Task<DepartmentDTO> UpdateDepartmentAsync(DepartmentDTO department)
        {
            return await base.UpdateEntityAsync(department);
        }

        protected override async Task<DepartmentDTO> GetEntitysByIdAsync(Guid id)
        {
            return _mapper.Map<DepartmentDTO>(await _repository.GetFirstBySpecAsync(new Departments.GetDepartmentById(id)));
        }
    }
}