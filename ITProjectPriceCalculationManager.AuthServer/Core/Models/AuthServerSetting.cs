namespace ITProjectPriceCalculationManager.AuthServer.Core.Models;

public class AuthServerSetting
{
    public required string ConnectionString { get; set; }
    public required string[] OriginUrls { get; set; }
}