using ITProjectPriceCalculationManager.AuthServer.Core.DTO;
using ITProjectPriceCalculationManager.AuthServer.Core.Models;

namespace ITProjectPriceCalculationManager.AuthServer.Core.Interfaces.Services
{
    public interface IAuthenticateSevice
    {
        Task<string> Register(RegisterModel model);
        Task RegisterAdmin(RegisterModel model);
        Task<TokenInfoDTO> Login(LoginModel model);
    }
}