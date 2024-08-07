using ITProjectPriceCalculationManager.Infrastructure.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationForEvaluation;

internal class ApplicationForEvaluation : IBaseEntity<Guid>
{
    public double Profit { get; set; }
    public double Overhead { get; set; }
    public double SocialInsurance { get; set; }
    public double AverageCostLabor { get; set; }
    public double AverageMonthlyRateWorkingHours { get; set; }
    public double? ConfidenceArea { get; set; }
    public Guid Id { get; set; }
}