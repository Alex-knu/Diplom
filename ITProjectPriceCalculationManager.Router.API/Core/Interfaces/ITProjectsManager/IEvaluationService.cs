using ITProjectPriceCalculationManager.DTOModels.DTO.ITProjectsManager;

namespace ITProjectPriceCalculationManager.Router.API.Core.Interfaces.ITProjectsManager;

public interface IEvaluationService
{
    Task<EvaluationDTO> CreateEvaluationAsync(EvaluationDTO evaluation);
    Task<EvaluationDTO> DeleteEvaluationAsync(Guid id);
    Task<IEnumerable<EvaluationDTO>> GetEvaluationsAsync();
    Task<EvaluationDTO> GetEvaluationsByIdAsync(Guid id);
    Task<EvaluationDTO> UpdateEvaluationAsync(EvaluationDTO evaluation);
}