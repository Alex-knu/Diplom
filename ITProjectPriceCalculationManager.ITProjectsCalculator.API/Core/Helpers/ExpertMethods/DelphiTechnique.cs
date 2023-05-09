using ITProjectPriceCalculationManager.DTOModels.Interfaces;
using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Models;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Helpers.ExpertMethods
{
    internal class DelphiTechnique
    {
        public CheckFactorsResult CheckFactors(IEnumerable<IFactor> factors, double confidenceArea)
        {
            CheckFactorsResult result = new CheckFactorsResult();

            double maxValue = factors.Max(f => f.Value);
            double minValue = factors.Min(f => f.Value);
            double quartile = (maxValue - minValue) / 4 ;

            if((maxValue - minValue - 2 * quartile) > confidenceArea)
            {
                result.Error = "dbjsabfdkas";
                return result;
            }

            result.FactorValue = factors.Sum(f => f.SelfEvaluation * f.Value) / factors.Count();

            if(factors.Any(f => f.Count.HasValue))
            {
                result.Count = (int)Math.Round((factors.Sum(f => f.SelfEvaluation * f.Count) / factors.Count()).Value);
            }

            return result;
        }
    }
}