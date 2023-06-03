namespace ITProjectPriceCalculationManager.DTOModels.DTO
{
    public class ProgramLanguageDTO
    {
        public Guid Id { get; set; }
        public int SLOC { get; set; }
        public string Name { get; set; }

        public List<ProgramsParametrDTO> ProgramsParametrs { get; set; }
    }
}