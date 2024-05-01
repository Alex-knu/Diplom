namespace ITProjectPriceCalculationManager.AuthServer.Core.Models;

public class AuthServerSetting
{
    public string ConnectionString { get; set; }
    public string[] OriginUrls { get; set; }
}