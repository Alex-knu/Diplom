namespace ITProjectPriceCalculationManager.Router.API.Core.Models;

public class JwtSetting
{
    public required string ValidAudience { get; set; }
    public required string ValidIssuer { get; set; }
    public required string Secret { get; set; }
}