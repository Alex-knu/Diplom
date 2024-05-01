using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.Router.API.Core.Interfaces;

public interface IProgramLanguageService
{
    Task<IEnumerable<ProgramLanguageDTO>> GetProgramLanguagesAsync();
    Task<IEnumerable<ProgramLanguageDTO>> GetAllProgramLanguagesByApplicationId(Guid applicationId);
}