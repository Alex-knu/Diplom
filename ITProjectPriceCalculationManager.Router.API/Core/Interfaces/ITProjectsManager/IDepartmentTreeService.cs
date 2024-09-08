using ITProjectPriceCalculationManager.DTOModels.DTO.ITProjectsManager;

namespace ITProjectPriceCalculationManager.Router.API.Core.Interfaces.ITProjectsManager;

public interface IDepartmentTreeService
{
    Task<IEnumerable<DepartmentDTO>> GetDepartmentsTreeAsync();
}