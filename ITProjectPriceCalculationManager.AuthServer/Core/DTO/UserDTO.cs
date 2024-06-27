namespace ITProjectPriceCalculationManager.AuthServer.Core.DTO;

public class UserDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required List<RoleDTO> Roles { get; set; }
}