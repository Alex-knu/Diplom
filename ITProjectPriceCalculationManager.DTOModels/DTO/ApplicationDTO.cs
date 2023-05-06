namespace ITProjectPriceCalculationManager.DTOModels.DTO
{
    public class ApplicationDTO : BaseApplicationDTO
    {
        public double Overhead { get; set; }
        public double SocialInsurance { get; set; }
        public double AverageCostLabor { get; set; }
        public double AverageMonthlyRateWorkingHours { get; set; }
        public List<ScaleFactorDTO> ScaleFactors{ get; set; }
        public List<InfluenceFactorDTO> InfluenceFactors{ get; set; }
        public List<ProgramsParametrDTO> ProgramsParametrs{ get; set; }
    }
}