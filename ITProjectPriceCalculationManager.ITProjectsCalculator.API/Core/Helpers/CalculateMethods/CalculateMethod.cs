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
                result.Result = (float)Math.Round(price.Value * evaluation.Overhead / 100 + price.Value * evaluation.Profit / 100 + price.Value * evaluation.SocialInsurance / 100, 2);
            }

            return Task.FromResult(result);
        }
    }
}