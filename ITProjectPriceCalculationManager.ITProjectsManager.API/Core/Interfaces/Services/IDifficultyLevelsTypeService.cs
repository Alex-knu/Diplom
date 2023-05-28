using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.DifficultyLevelsType;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services
{
    public interface IDifficultyLevelsTypeService
    {
        IEnumerable<DifficultyLevelsTypeDTO> GetDifficultyLevelTypesForFactorType(int difficultyLevelId);
    }
}