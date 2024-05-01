namespace ITProjectPriceCalculationManager.DTOModels.DTO;

public class UserContextDTO
{
    public Guid UserId { get; set; }
    public List<string> Roles { get; set; }
}