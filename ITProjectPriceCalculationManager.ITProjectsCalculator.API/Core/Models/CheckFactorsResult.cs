namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Models;

internal class CheckFactorsResult
{
    public int Count { get; set; }
    public required string Error { get; set; }
    public double FactorValue { get; set; }
}