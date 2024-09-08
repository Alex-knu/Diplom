namespace ITProjectPriceCalculationManager.DTOModels.DTO.ITProjectsManager;

public class ProgramsParametrEvaluationFactorDTO
{
    public Guid Id { get; set; }
    public int SLOC { get; set; }
    public required string ProgramLanguageName { get; set; }
    public required List<EvaluationFactorDTO> SubjectAreaElements { get; set; }
}