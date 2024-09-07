using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.Router.API.Core.Interfaces.ITProjectsManager;

public interface IDepartmentTreeService
{
    Task<IEnumerable<DepartmentDTO>> GetDepartmentsTreeAsync();
}