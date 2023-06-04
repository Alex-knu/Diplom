using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.Router.API.Core.Interfaces
{
    public interface IEvaluationService
    {
        Task<EvaluationDTO> CreateEvaluationAsync(EvaluationDTO evaluation);
        Task<EvaluationDTO> DeleteEvaluationAsync(Guid id);
        Task<IEnumerable<EvaluationDTO>> GetEvaluationsAsync();
        Task<EvaluationDTO> GetEvaluationsByIdAsync(Guid id);
        Task<EvaluationDTO> UpdateEvaluationAsync(EvaluationDTO evaluation);
    }
}