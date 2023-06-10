namespace ITProjectPriceCalculationManager.Router.API.Core.Models
{
    public class RouteSetting
    {
        public string AuthServer { get; set; }
        public string ITProjectsManagerAPIRoute { get; set; }
        public string ITProjectsCalculatorAPIRoute { get; set; }
        public string[] OriginUrls { get; set; }
    }
}