namespace ITProjectPriceCalculationManager.DTOModels.DTO;

public class BaseApplicationDTO
{
    public Guid Id { get; set; }
    public Guid CreatorId { get; set; }
    public Guid StatusId { get; set; }
    public Guid UserCreatorId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public string? StatusName { get; set; }
    public double? Price { get; set; }
    public double Profit { get; set; }
    public double? ConfidenceArea { get; set; }
    public double Overhead { get; set; }
    public double SocialInsurance { get; set; }
    public double AverageCostLabor { get; set; }
    public double AverageMonthlyRateWorkingHours { get; set; }
}