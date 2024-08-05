using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces.Services;

public interface IEvaluateParameterService
{
    Task<IEnumerable<EvaluateParameterDTO>> GetEvaluateParametersByParameterIdAsync(Guid parameterId);
    Task<IEnumerable<EvaluateParameterDTO>> GetEvaluateParameterAsync();
    Task<EvaluateParameterDTO> CreateEvaluateParameterAsync(EvaluateParameterDTO dto);
    Task<EvaluateParameterDTO> UpdateEvaluateParameterAsync(EvaluateParameterDTO query);
    Task<EvaluateParameterDTO> DeleteEvaluateParameterAsync(Guid id);
}