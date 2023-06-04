using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.Router.API.Core.Interfaces
{
    public interface IEvaluatorService
    {
        Task<IEnumerable<EvaluatorDTO>> GetEvaluatorsAsync();
        Task<EvaluatorDTO> GetEvaluatorsByIdAsync(Guid id);
        Task<EvaluatorDTO> CreateEvaluatorAsync(EvaluatorDTO evaluator);
        Task<EvaluatorDTO> UpdateEvaluatorAsync(EvaluatorDTO evaluator);
        Task<EvaluatorDTO> DeleteEvaluatorAsync(Guid id);
    }
}