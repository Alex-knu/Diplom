using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.Router.API.Core.Interfaces
{
    public interface IEvaluationParametrsInfoService
    {
        Task<IEnumerable<EvaluationParametrsInfoDTO>> GetEvaluationAttributes();
    }
}