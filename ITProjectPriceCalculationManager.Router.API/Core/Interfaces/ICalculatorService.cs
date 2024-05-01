using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.Router.API.Core.Interfaces;

public interface ICalculatorService
{
    Task<BaseApplicationDTO> CalculateApplicationPriceAsync(Guid applicationId);
}