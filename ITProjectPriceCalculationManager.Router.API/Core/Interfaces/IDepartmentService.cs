using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.Router.API.Core.Interfaces;

public interface IDepartmentService
{
    Task<IEnumerable<DepartmentDTO>> GetDepartmentsAsync();
    Task<DepartmentDTO> GetDepartmentsByIdAsync(Guid id);
    Task<DepartmentDTO> CreateDepartmentAsync(DepartmentDTO department);
    Task<DepartmentDTO> UpdateDepartmentAsync(DepartmentDTO department);
    Task<DepartmentDTO> DeleteDepartmentAsync(Guid id);
}