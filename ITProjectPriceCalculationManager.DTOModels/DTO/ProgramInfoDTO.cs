namespace ITProjectPriceCalculationManager.DTOModels.DTO;

public class ProgramInfoDTO
{
    public Guid Id { get; set; }
    public required List<ApplicationToFactorsDTO> ApplicationToFactors { get; set; }
}