using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;

public interface IEvaluatorService
{
    Task<IEnumerable<EvaluatorDTO>> GetEvaluatorsAsync(List<Guid> userIds);
    Task<EvaluatorDTO> GetEvaluatorsByIdAsync(Guid id);
    Task<EvaluatorDTO> CreateEvaluatorAsync(EvaluatorDTO evaluator);
    Task<EvaluatorDTO> UpdateEvaluatorAsync(EvaluatorDTO evaluator);
    Task<EvaluatorDTO> DeleteEvaluatorAsync(Guid id);
}