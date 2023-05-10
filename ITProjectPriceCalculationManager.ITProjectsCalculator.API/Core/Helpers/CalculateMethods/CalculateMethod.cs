using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Helpers.CalculateMethods
{
    internal abstract class CalculateMethod
    {
        public virtual Task<EvaluationResultDTO> Calculate(EvaluationDTO evaluation, double? price)
        {
            EvaluationResultDTO result = new EvaluationResultDTO();

            if (price.HasValue)
            {
                result.Result = price.Value * evaluation.Overhead + price.Value * evaluation.Profit + price.Value * evaluation.SocialInsurance;
            }

            return Task.FromResult(result);
        }
    }
}