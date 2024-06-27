namespace ITProjectPriceCalculationManager.Extentions.Models;

public class UserInfo
{
    public Guid UserId { get; set; }
    public required string UserName { get; set; }
    public required List<string> Roles { get; set; }
}