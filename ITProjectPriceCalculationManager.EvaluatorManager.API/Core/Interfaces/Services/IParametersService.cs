using ITProjectPriceCalculationManager.DTOModels.DTO.FuzzyLogic;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces.Services;

public interface IParametersService
{
    Task<IEnumerable<ParametersDTO>> GetParametersByApplicationIdAsync(Guid applicationId);
    Task<IEnumerable<ParametersDTO>> GetParametersAsync();
    Task<ParametersDTO> CreateParametersAsync(ParametersDTO dto);
    Task<ParametersDTO> UpdateParametersAsync(ParametersDTO query);
    Task<ParametersDTO> DeleteParametersAsync(Guid id);
}