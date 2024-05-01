using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces.Services;

public interface IParametersService
{
    Task<IEnumerable<ParametersDTO>> GetParametersAsync();
    Task<ParametersDTO> GetParametersByIdAsync(Guid id);
    Task<ParametersDTO> CreateParametersAsync(ParametersDTO dto);
    Task<ParametersDTO> UpdateParametersAsync(ParametersDTO query);
    Task<ParametersDTO> DeleteParametersAsync(Guid id);
}