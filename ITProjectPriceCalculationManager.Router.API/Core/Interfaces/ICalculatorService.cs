using ITProjectPriceCalculationManager.DTOModels.DTO.ITProjectsManager;

namespace ITProjectPriceCalculationManager.Router.API.Core.Interfaces;

public interface ICalculatorService
{
    Task<BaseApplicationDTO> CalculateApplicationPriceAsync(Guid applicationId);
}