using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services
{
    public interface IEvaluationParametrsInfoService
    {
        IEnumerable<EvaluationParametrsInfoDTO> GetEvaluationAttributes();
    }
}