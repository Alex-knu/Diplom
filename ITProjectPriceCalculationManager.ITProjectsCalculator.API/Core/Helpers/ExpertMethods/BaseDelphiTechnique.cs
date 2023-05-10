using ITProjectPriceCalculationManager.DTOModels.Interfaces;
using ITProjectPriceCalculationManager.Extentions.Models.Exceptions;
using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Models;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Helpers.ExpertMethods
{
    internal abstract class BaseDelphiTechnique
    {
        public CheckFactorsResult CheckFactors(IEnumerable<IFactor> factors, double? confidenceArea){
            CheckFactorsResult result = new CheckFactorsResult();

            double maxValue = factors.Max(f => f.Value);
            double minValue = factors.Min(f => f.Value);
            double quartile = (maxValue - minValue) / 4;

            if (CheckCondition(factors, confidenceArea.Value))
            {
                throw new BadRequestException("The assessment is beyond the limits of confidence");
            }

            result.FactorValue = GetSumOfValue(factors) / factors.Count();

            if (factors.All(f => f.Count.HasValue))
            {
                result.Count = (int)Math.Round((GetSumOfCount(factors) / factors.Count()));
            }

            return result;
        }
        
        protected abstract bool CheckCondition(IEnumerable<IFactor> factors, double etalon);
        protected abstract double GetSumOfValue(IEnumerable<IFactor> factors);
        protected abstract double GetSumOfCount(IEnumerable<IFactor> factors);
    }
}