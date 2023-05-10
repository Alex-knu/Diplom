namespace ITProjectPriceCalculationManager.DTOModels.DTO
{
    public class ApplicationDTO : BaseApplicationDTO
    {
        public double? ConfidenceArea { get; set; }
        public double Overhead { get; set; }
        public double SocialInsurance { get; set; }
        public double AverageCostLabor { get; set; }
        public double AverageMonthlyRateWorkingHours { get; set; }
        public List<FactorDTO> ScaleFactors{ get; set; }
        public List<FactorDTO> InfluenceFactors{ get; set; }
        public List<EvaluationFactorDTO> EvaluationFactors{ get; set; }
        public List<ProgramsParametrDTO> ProgramsParametrs{ get; set; }
        public List<ProgramsParametrEvaluationFactorDTO> ProgramsParametrEvaluationFactorDTO{ get; set; }
    }
}