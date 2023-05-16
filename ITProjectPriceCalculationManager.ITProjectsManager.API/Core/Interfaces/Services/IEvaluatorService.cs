using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services
{
    public interface IEvaluatorService
    {
        Task<IEnumerable<EvaluatorDTO>> GetEvaluatorsAsync();
        Task<EvaluatorDTO> GetEvaluatorsByIdAsync(int id);
        Task<EvaluatorDTO> CreateEvaluatorAsync(EvaluatorDTO evaluator);
        Task<EvaluatorDTO> UpdateEvaluatorAsync(EvaluatorDTO evaluator);
        Task<EvaluatorDTO> DeleteEvaluatorAsync(int id);
    }
}