using ITProjectPriceCalculationManager.AuthServer.Core.DTO;

namespace ITProjectPriceCalculationManager.AuthServer.Core.Interfaces.Services;

public interface IUserSevice
{
    IEnumerable<UserDTO> GetAllUsers();
    IEnumerable<string> GetAllUserIdsByRole(string roleName);
    Task<UserDTO> UpdateUserRoles(UserDTO query);
}