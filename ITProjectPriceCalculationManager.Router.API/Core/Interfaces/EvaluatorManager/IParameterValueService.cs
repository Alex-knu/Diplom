using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.Router.API.Core.Interfaces.EvaluatorManager;

public interface IParameterValueService
{
    Task<IEnumerable<ParameterValueDTO>> GetParameterValueAsync();
    Task<ParameterValueDTO> GetParameterValueByIdAsync(Guid id);
    Task<ParameterValueDTO> CreateParameterValueAsync(ParameterValueDTO dto);
    Task<ParameterValueDTO> UpdateParameterValueAsync(ParameterValueDTO query);
    Task<ParameterValueDTO> DeleteParameterValueAsync(Guid id);
}