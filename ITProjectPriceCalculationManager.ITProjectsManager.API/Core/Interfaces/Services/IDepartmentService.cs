using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDTO>> GetDepartmentsAsync();
        Task<IEnumerable<DepartmentDTO>> GetDepartmentsTreeAsync();
        Task<DepartmentDTO> GetDepartmentsByIdAsync(int id);
        Task<DepartmentDTO> CreateDepartmentAsync(DepartmentDTO department);
        Task<DepartmentDTO> UpdateDepartmentAsync(DepartmentDTO department);
        Task<DepartmentDTO> DeleteDepartmentAsync(int id);
    }
}