using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Application
{
    internal class Application : IBaseEntity<int>
    {
        public int Id { get; set; }
        public int  CreatorId { get; set; }
        public double Price { get; set; }
        public double Profit { get; set; }
        public double Overhead { get; set; }
        public double SocialInsurance { get; set; }
        public double AverageCostLabor { get; set; }
        public double AverageMonthlyRateWorkingHours { get; set; }

        public Estimator.Estimator Creator { get; set; }
        public ICollection<ApplicationToEstimators.ApplicationToEstimators> ApplicationToEstimators { get; set; }
        //public virtual ICollection<ScaleFactor> ScaleFactors{ get; set; }
        //public virtual ICollection<InfluenceFactor> InfluenceFactors{ get; set; }
        public virtual ICollection<ProgramsParametr.ProgramsParametr> ProgramsParametrs { get; set; }
    }
}