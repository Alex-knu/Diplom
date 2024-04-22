using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;

public interface IDepartmentTreeService
{
    Task<IEnumerable<DepartmentDTO>> GetDepartmentsTreeAsync();
}