using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces.Services;

public interface IEvaluateParameterValueService
{
    Task<IEnumerable<EvaluateParameterValueDTO>> GetEvaluateParameterValueAsync();
    Task<EvaluateParameterValueDTO> GetEvaluateParameterValueByIdAsync(Guid id);
    Task<EvaluateParameterValueDTO> CreateEvaluateParameterValueAsync(EvaluateParameterValueDTO dto);
    Task<EvaluateParameterValueDTO> UpdateEvaluateParameterValueAsync(EvaluateParameterValueDTO query);
    Task<EvaluateParameterValueDTO> DeleteEvaluateParameterValueAsync(Guid id);
}