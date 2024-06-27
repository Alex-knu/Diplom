namespace ITProjectPriceCalculationManager.DTOModels.DTO;

public class ProgramLanguageDTO
{
    public Guid Id { get; set; }
    public int SLOC { get; set; }
    public required string Name { get; set; }

    public required List<ProgramsParametrDTO> ProgramsParametrs { get; set; }
}