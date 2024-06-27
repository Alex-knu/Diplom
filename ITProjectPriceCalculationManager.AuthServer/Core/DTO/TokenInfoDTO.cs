namespace ITProjectPriceCalculationManager.AuthServer.Core.DTO;

public class TokenInfoDTO
{
    public required string Token { get; set; }
    public DateTime Expiration { get; set; }
}