using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.DTOModels.DTO.ITProjectsManager;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Helpers.CalculateMethods;

internal abstract class CalculateMethod
{
    public virtual Task<EvaluationResultDTO> Calculate(EvaluationDTO evaluation, double? price)
    {
        var result = new EvaluationResultDTO() { Error = string.Empty };

        if (price.HasValue)
            result.Result =
                (float)Math.Round(
                    price.Value * evaluation.Overhead / 100 + price.Value * evaluation.Profit / 100 +
                    price.Value * evaluation.SocialInsurance / 100, 2);

        return Task.FromResult(result);
    }
}