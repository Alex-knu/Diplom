using ITProjectPriceCalculationManager.AuthServer.Core.DTO;

namespace ITProjectPriceCalculationManager.AuthServer.Core.Interfaces.Services
{
    public interface IUserSevice
    {
        IEnumerable<UserDTO> GetAllUsers();
    }
}