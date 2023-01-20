using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Interfaces.Services
{
    public interface ICalculateService
    {
        ApplicationDTO AlbrehtMethodCalculate(ApplicationDTO application);
    }
}