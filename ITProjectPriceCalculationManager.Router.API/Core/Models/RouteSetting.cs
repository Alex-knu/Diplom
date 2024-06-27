namespace ITProjectPriceCalculationManager.Router.API.Core.Models;

public class RouteSetting
{
    public required string AuthServer { get; set; }
    public required string ITProjectsManagerAPIRoute { get; set; }
    public required string ITProjectsCalculatorAPIRoute { get; set; }
    public required string[] OriginUrls { get; set; }
}