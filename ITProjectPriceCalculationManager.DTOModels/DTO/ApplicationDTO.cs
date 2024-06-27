namespace ITProjectPriceCalculationManager.DTOModels.DTO;

public class ApplicationDTO : BaseApplicationDTO
{
    public required List<FactorDTO> ScaleFactors { get; set; }
    public required List<FactorDTO> InfluenceFactors { get; set; }
    public required List<EvaluationFactorDTO> EvaluationFactors { get; set; }
    public required List<ProgramsParametrDTO> ProgramsParametrs { get; set; }
    public required List<ProgramsParametrEvaluationFactorDTO> ProgramsParametrEvaluationFactorDTO { get; set; }
}