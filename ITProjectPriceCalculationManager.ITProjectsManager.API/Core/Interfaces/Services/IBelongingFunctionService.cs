using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;

public interface IBelongingFunctionService
{
    Task<IEnumerable<BelongingFunctionDTO>> GetBelongingFunctionAsync();
    Task<BelongingFunctionDTO> CreateBelongingFunctionAsync(BelongingFunctionDTO dto);
    Task<BelongingFunctionDTO> UpdateBelongingFunctionAsync(BelongingFunctionDTO query);
    Task<BelongingFunctionDTO> DeleteBelongingFunctionAsync(Guid id);
}