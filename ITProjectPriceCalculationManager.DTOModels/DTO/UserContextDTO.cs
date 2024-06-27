namespace ITProjectPriceCalculationManager.DTOModels.DTO;

public class UserContextDTO
{
    public Guid UserId { get; set; }
    public required List<string> Roles { get; set; }
}