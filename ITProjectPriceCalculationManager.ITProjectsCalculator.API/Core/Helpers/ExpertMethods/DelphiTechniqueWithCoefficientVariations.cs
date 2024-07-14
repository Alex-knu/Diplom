using ITProjectPriceCalculationManager.DTOModels.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Helpers.ExpertMethods;

internal class DelphiTechniqueWithCoefficientVariations : BaseDelphiTechnique
{
    protected override bool CheckCondition(IEnumerable<IFactor> factors, double? etalon)
    {
        var midleValue = GetSumOfValue(factors) / factors.Count();
        var standardDeviation = Math.Sqrt(factors.Sum(f => f.Value - midleValue) / factors.Count());

        return standardDeviation * 100 / midleValue > 33;
    }

    protected override double GetSumOfValue(IEnumerable<IFactor> factors)
    {
        return factors.Sum(f => f.Value);
    }

    protected override double GetSumOfCount(IEnumerable<IFactor> factors)
    {
        return factors.Sum(f => f.Count ?? 0);
    }
}