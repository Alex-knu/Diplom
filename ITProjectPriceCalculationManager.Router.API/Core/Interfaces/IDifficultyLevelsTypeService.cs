using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.Router.API.Core.Interfaces
{
    public interface IDifficultyLevelsTypeService
    {
        Task<IEnumerable<DifficultyLevelsTypeDTO>> GetDifficultyLevelTypesForFactorType(Guid id);
    }
}