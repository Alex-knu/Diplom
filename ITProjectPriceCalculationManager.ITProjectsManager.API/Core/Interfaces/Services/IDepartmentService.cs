using ITProjectPriceCalculationManager.DTOModels.DTO.ITProjectsManager;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;

public interface IDepartmentService
{
    Task<IEnumerable<DepartmentDTO>> GetDepartmentsAsync();
    Task<DepartmentDTO> GetDepartmentsByIdAsync(Guid id);
    Task<DepartmentDTO> CreateDepartmentAsync(DepartmentDTO department);
    Task<DepartmentDTO> UpdateDepartmentAsync(DepartmentDTO department);
    Task<DepartmentDTO> DeleteDepartmentAsync(Guid id);
}