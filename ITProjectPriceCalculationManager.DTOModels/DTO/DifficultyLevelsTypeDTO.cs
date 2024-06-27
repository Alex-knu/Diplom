namespace ITProjectPriceCalculationManager.DTOModels.DTO;

public class DifficultyLevelsTypeDTO
{
    public Guid Id { get; set; }
    public Guid RelationId { get; set; }
    public required string Name { get; set; }
}