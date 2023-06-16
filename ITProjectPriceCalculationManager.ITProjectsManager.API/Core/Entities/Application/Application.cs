using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Application
{
    internal class Application : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid CreatorId { get; set; }
        public double Price { get; set; }
        public double Profit { get; set; }
        public double Overhead { get; set; }
        public double SocialInsurance { get; set; }
        public double AverageCostLabor { get; set; }
        public double AverageMonthlyRateWorkingHours { get; set; }
        public double? ConfidenceArea { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public string Status { get; set; } 

        public Evaluator.Evaluator Creator { get; set; }
        public ICollection<ApplicationToEvaluator.ApplicationToEvaluator> ApplicationToEvaluators { get; set; }
        public virtual ICollection<ApplicationToFactor.ApplicationToFactor> Factors{ get; set; }
        public virtual ICollection<ProgramsParametr.ProgramsParametr> ProgramsParametrs { get; set; }
    }
}