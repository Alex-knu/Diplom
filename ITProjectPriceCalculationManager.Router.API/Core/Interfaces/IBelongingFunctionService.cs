using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.Router.API.Core.Interfaces;

public interface IBelongingFunctionService
{
    Task<IEnumerable<BelongingFunctionDTO>> GetBelongingFunctionAsync();
    Task<BelongingFunctionDTO> GetBelongingFunctionByIdAsync(Guid id);
    Task<BelongingFunctionDTO> CreateBelongingFunctionAsync(BelongingFunctionDTO dto);
    Task<BelongingFunctionDTO> UpdateBelongingFunctionAsync(BelongingFunctionDTO query);
    Task<BelongingFunctionDTO> DeleteBelongingFunctionAsync(Guid id);
}