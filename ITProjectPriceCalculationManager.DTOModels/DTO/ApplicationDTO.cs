namespace ITProjectPriceCalculationManager.DTOModels.DTO;

public class ApplicationDTO : BaseApplicationDTO
{
    public List<FactorDTO> ScaleFactors { get; set; }
    public List<FactorDTO> InfluenceFactors { get; set; }
    public List<EvaluationFactorDTO> EvaluationFactors { get; set; }
    public List<ProgramsParametrDTO> ProgramsParametrs { get; set; }
    public List<ProgramsParametrEvaluationFactorDTO> ProgramsParametrEvaluationFactorDTO { get; set; }
}