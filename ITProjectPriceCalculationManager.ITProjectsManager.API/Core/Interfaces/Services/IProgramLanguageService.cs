using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;

public interface IProgramLanguageService
{
    Task<IEnumerable<ProgramLanguageDTO>> GetProgramLanguagesAsync();
    Task<IEnumerable<ProgramLanguageDTO>> GetAllProgramLanguagesByApplicationId(Guid applicationId);
}