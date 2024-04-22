namespace ITProjectPriceCalculationManager.Router.API.Core.Models;

public class JwtSetting
{
    public string ValidAudience { get; set; }
    public string ValidIssuer { get; set; }
    public string Secret { get; set; }
}