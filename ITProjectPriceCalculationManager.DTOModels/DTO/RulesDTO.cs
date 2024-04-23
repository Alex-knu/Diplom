namespace ITProjectPriceCalculationManager.DTOModels.DTO;

public class RulesDTO
{
    public Guid IfParameterId { get; set; }
    public Guid IfValueId { get; set; }
    public Guid ThenParameterId { get; set; }
    public Guid ThenValueId { get; set; }
}