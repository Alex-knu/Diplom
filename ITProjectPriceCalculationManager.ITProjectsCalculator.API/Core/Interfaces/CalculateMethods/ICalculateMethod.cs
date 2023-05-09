using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Interfaces.CalculateMethods
{
    internal interface ICalculateMethod
    {
         public Task<ApplicationDTO> Calculate(ApplicationDTO application);
    }
}