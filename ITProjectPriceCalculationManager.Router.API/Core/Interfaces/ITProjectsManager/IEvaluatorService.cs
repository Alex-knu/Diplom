using ITProjectPriceCalculationManager.DTOModels.DTO.ITProjectsManager;

namespace ITProjectPriceCalculationManager.Router.API.Core.Interfaces.ITProjectsManager;

public interface IEvaluatorService
{
    Task<IEnumerable<EvaluatorDTO>> GetEvaluatorsAsync(HttpContext httpContext);
    Task<EvaluatorDTO> GetEvaluatorsByIdAsync(Guid id);
    Task<EvaluatorDTO> CreateEvaluatorAsync(EvaluatorDTO evaluator);
    Task<EvaluatorDTO> UpdateEvaluatorAsync(EvaluatorDTO evaluator);
    Task<EvaluatorDTO> DeleteEvaluatorAsync(Guid id);
}