namespace ITProjectPriceCalculationManager.DTOModels.DTO
{
    public class ProgramsParametrDTO
    {
        public int Id { get; set; }
        public int SLOC { get; set; }
        public string ProgramLanguageName { get; set; }
        public List<SubjectAreaElementDTO> SubjectAreaElements{ get; set; }
    }
}