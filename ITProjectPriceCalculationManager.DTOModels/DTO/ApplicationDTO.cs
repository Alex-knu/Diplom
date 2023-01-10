namespace ITProjectPriceCalculationManager.DTOModels.DTO
{
    public class ApplicationDTO
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public List<ScaleFactorDTO> ScaleFactors{ get; set; }
        public List<InfluenceFactorDTO> InfluenceFactors{ get; set; }
        public List<ProgramsParametrDTO> ProgramsParametrs{ get; set; }
    }
}