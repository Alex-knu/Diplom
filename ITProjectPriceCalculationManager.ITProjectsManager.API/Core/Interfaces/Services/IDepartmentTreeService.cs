using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services
{
    public interface IDepartmentTreeService
    {
        Task<IEnumerable<DepartmentDTO>> GetDepartmentsTreeAsync();
    }
}