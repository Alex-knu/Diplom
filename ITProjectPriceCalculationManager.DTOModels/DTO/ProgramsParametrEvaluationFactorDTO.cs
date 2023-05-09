namespace ITProjectPriceCalculationManager.DTOModels.DTO
{
    public class ProgramsParametrEvaluationFactorDTO
    {
        public int Id { get; set; }
        public int SLOC { get; set; }
        public string ProgramLanguageName { get; set; }
        public List<EvaluationFactorDTO> SubjectAreaElements{ get; set; }
    }
}