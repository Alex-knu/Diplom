using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Department;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Repositories;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services
{
    internal class DepartmentService : IDepartmentService
    {
        protected readonly IRepository<Department, int> _departmentRepository;
        protected readonly IMapper _mapper;

        public DepartmentService(IRepository<Department, int> departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<DepartmentDTO> CreateDepartmentAsync(DepartmentDTO department)
        {
            try
            {
                var domainDepartment = _mapper.Map<Department>(department);

                var newDepartment = await _departmentRepository.AddAsync(domainDepartment);
                await _departmentRepository.SaveChangesAcync();

                return _mapper.Map<DepartmentDTO>(newDepartment);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DepartmentDTO> DeleteDepartmentAsync(int id)
        {
            var domainDepartment = await _departmentRepository.GetByKeyAsync(id);

            if (domainDepartment == null)
            {
                throw new BadHttpRequestException("Department not found");
            }

            var deleteDepartment = await _departmentRepository.DeleteAsync(domainDepartment);
            await _departmentRepository.SaveChangesAcync();

            return _mapper.Map<DepartmentDTO>(deleteDepartment);
        }

        public async Task<IEnumerable<DepartmentDTO>> GetDepartmentsAsync()
        {
            var domainDepartments = await _departmentRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<DepartmentDTO>>(domainDepartments);
        }

        public async Task<DepartmentDTO> GetDepartmentsByIdAsync(int id)
        {
            var domainDepartment = await _departmentRepository.GetByKeyAsync(id);

            return _mapper.Map<DepartmentDTO>(domainDepartment);
        }

        public async Task<DepartmentDTO> UpdateDepartmentAsync(DepartmentDTO department)
        {
            try
            {
                var domainDepartment = _mapper.Map<Department>(department);

                var updateDepartment = await _departmentRepository.UpdateAsync(domainDepartment);
                await _departmentRepository.SaveChangesAcync();

                return _mapper.Map<DepartmentDTO>(updateDepartment);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}