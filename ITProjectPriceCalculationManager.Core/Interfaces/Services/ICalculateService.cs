using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.Core.Interfaces.Services
{
    public interface ICalculateService
    {
        ApplicationDTO AlbrehtMethodCalculate(ApplicationDTO application);
    }
}