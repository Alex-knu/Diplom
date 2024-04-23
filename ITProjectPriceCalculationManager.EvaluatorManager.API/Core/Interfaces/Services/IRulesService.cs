using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces.Services;

public interface IRulesService
{
    Task<IEnumerable<RulesDTO>> GetRulesAsync();
    Task<RulesDTO> GetRulesByIdAsync(Guid id);
    Task<RulesDTO> CreateRulesAsync(RulesDTO dto);
    Task<RulesDTO> UpdateRulesAsync(RulesDTO query);
    Task<RulesDTO> DeleteRulesAsync(Guid id);
}