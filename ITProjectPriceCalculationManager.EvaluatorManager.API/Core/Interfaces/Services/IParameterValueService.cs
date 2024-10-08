using ITProjectPriceCalculationManager.DTOModels.DTO.FuzzyLogic;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces.Services;

public interface IParameterValueService
{
    Task<IEnumerable<ParameterValueDTO>> GetParameterValueAsync();
    Task<ParameterValueDTO> GetParameterValueByIdAsync(Guid id);
    Task<ParameterValueDTO> CreateParameterValueAsync(ParameterValueDTO dto);
    Task<ParameterValueDTO> UpdateParameterValueAsync(ParameterValueDTO query);
    Task<ParameterValueDTO> DeleteParameterValueAsync(Guid id);
}