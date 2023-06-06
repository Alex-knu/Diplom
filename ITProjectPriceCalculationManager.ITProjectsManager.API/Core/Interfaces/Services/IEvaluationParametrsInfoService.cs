using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services
{
    public interface IEvaluationParametrsInfoService
    {
        Task<IEnumerable<EvaluationParametrsInfoDTO>> GetEvaluationAttributes();
    }
}