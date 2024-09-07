using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.Router.API.Core.Interfaces.EvaluatorManager;

public interface IParametersService
{
    Task<IEnumerable<ParametersDTO>> GetParameterByApplicationIdAsync(Guid applicationId);
    Task<IEnumerable<ParametersDTO>> GetParametersAsync();
    Task<ParametersDTO> GetParametersByIdAsync(Guid id);
    Task<ParametersDTO> CreateParametersAsync(ParametersDTO dto);
    Task<ParametersDTO> UpdateParametersAsync(ParametersDTO query);
    Task<ParametersDTO> DeleteParametersAsync(Guid id);
}