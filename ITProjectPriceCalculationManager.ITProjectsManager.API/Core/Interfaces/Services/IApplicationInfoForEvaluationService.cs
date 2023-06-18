using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services
{
    public interface IApplicationInfoForEvaluationService
    {
        Task<EvaluationDTO> GetForEvaluation(Guid applicationId);
    }
}