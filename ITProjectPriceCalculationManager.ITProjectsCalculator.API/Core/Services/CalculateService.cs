using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Interfaces.Services;
using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Helpers.CalculateMethods;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Services
{
    internal class CalculateService : ICalculateService
    {
        public Task<EvaluationResultDTO> Calculate(EvaluationDTO evaluation, double? price = null)
        {
            return SetStrategy().Calculate(evaluation, price);
        }

        private CalculateMethod SetStrategy()
        {
            return new AlbrehtMethod();
        }
    }
}