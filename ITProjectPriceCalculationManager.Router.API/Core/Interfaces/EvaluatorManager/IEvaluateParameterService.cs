using ITProjectPriceCalculationManager.DTOModels.DTO.FuzzyLogic;

namespace ITProjectPriceCalculationManager.Router.API.Core.Interfaces.EvaluatorManager;

public interface IEvaluateParameterService
{
    Task<IEnumerable<EvaluateParameterDTO>> GetEvaluateParametersByParameterIdAsync(Guid parameterId);
    Task<IEnumerable<EvaluateParameterDTO>> GetEvaluateParameterAsync();
    Task<EvaluateParameterDTO> GetEvaluateParameterByIdAsync(Guid id);
    Task<EvaluateParameterDTO> CreateEvaluateParameterAsync(EvaluateParameterDTO dto);
    Task<EvaluateParameterDTO> UpdateEvaluateParameterAsync(EvaluateParameterDTO query);
    Task<EvaluateParameterDTO> DeleteEvaluateParameterAsync(Guid id);
}