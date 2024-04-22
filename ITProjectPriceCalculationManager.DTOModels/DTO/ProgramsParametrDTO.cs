namespace ITProjectPriceCalculationManager.DTOModels.DTO;

public class ProgramsParametrDTO
{
    public Guid Id { get; set; }
    public List<ApplicationToFactorsDTO> ApplicationToFactors { get; set; }
}