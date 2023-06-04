using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.Router.API.Core.Interfaces
{
    public interface IDepartmentTreeService
    {
        Task<IEnumerable<DepartmentDTO>> GetDepartmentsTreeAsync();
    }
}