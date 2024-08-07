using ITProjectPriceCalculationManager.DTOModels.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Helpers.ExpertMethods;

internal class DelphiTechniqueWithConfidenceArea : BaseDelphiTechnique
{
    protected override bool CheckCondition(IEnumerable<IFactor> factors, double? etalon)
    {
        var maxValue = factors.Max(f => f.Value);
        var minValue = factors.Min(f => f.Value);
        var quartile = (maxValue - minValue) / 4;

        return maxValue - minValue - 2 * quartile > etalon;
    }

    protected override double GetSumOfValue(IEnumerable<IFactor> factors)
    {
        return factors.Sum(f => f.SelfEvaluation * f.Value);
    }

    protected override double GetSumOfCount(IEnumerable<IFactor> factors)
    {
        return factors.Sum(f => f.SelfEvaluation * f.Count ?? 0);
    }
}