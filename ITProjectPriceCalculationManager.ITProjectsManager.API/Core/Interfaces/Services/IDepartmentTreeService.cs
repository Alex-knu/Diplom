using ITProjectPriceCalculationManager.DTOModels.DTO.ITProjectsManager;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;

public interface IDepartmentTreeService
{
    Task<IEnumerable<DepartmentDTO>> GetDepartmentsTreeAsync();
}