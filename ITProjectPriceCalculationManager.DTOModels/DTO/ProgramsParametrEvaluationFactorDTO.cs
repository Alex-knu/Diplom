namespace ITProjectPriceCalculationManager.DTOModels.DTO
{
    public class ProgramsParametrEvaluationFactorDTO
    {
        public Guid Id { get; set; }
        public int SLOC { get; set; }
        public string ProgramLanguageName { get; set; }
        public List<EvaluationFactorDTO> SubjectAreaElements{ get; set; }
    }
}