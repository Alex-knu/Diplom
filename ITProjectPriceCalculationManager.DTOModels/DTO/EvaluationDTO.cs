namespace ITProjectPriceCalculationManager.DTOModels.DTO.ITProjectsManager;

public class EvaluationDTO
{
    public Guid Id { get; set; }
    public double AverageCostLabor { get; set; }
    public double AverageMonthlyRateWorkingHours { get; set; }
    public double? ConfidenceArea { get; set; }
    public double Overhead { get; set; }
    public double Profit { get; set; }
    public double SocialInsurance { get; set; }
    
    public required List<EvaluationFactorDTO> EvaluationFactors { get; set; }
    public required List<ProgramsParametrEvaluationFactorDTO> ProgramsParametrEvaluationFactor { get; set; }
}