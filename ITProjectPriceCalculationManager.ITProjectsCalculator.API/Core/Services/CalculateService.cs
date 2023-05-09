using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Interfaces.Services;
using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Helpers.CalculateMethods;
using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Interfaces.CalculateMethods;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Services
{
    internal class CalculateService : ICalculateService
    {
        public Task<ApplicationDTO> Calculate(ApplicationDTO application)
        {
            return SetStrategy().Calculate(application);
        }

        private ICalculateMethod SetStrategy()
        {
            return new AlbrehtMethod();
        }
    }
}