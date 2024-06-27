namespace ITProjectPriceCalculationManager.DTOModels.DTO;

public class ProgramsParametrDTO
{
    public Guid Id { get; set; }
    public required List<ApplicationToFactorsDTO> ApplicationToFactors { get; set; }
}