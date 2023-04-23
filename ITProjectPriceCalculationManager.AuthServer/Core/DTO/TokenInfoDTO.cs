namespace ITProjectPriceCalculationManager.AuthServer.Core.DTO
{
    public class TokenInfoDTO
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}