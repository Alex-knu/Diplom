namespace ITProjectPriceCalculationManager.DTOModels.DTO
{
    public class BaseApplicationDTO
    {
        public Guid Id { get; set; }
        public Guid CreatorId { get; set; }
        public Guid UserCreatorId { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public string Status { get; set; } 
        public double? Price { get; set; }
        public double Profit { get; set; }
        public double? ConfidenceArea { get; set; }
        public double Overhead { get; set; }
        public double SocialInsurance { get; set; }
        public double AverageCostLabor { get; set; }
        public double AverageMonthlyRateWorkingHours { get; set; }
        public List<ProgramLanguageDTO>? ProgramLanguages{ get; set; }
    }
}