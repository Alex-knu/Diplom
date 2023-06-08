using ITProjectPriceCalculationManager.AuthServer.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.AuthServer.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserSevice _userSevice;

        public UserController(IUserSevice userSevice)
        {
            _userSevice = userSevice;
        }

        
        [HttpGet]
        [Route("collection")]
        public IActionResult GetAllUsers()
        {
            return Ok(_userSevice.GetAllUsers());
        }
    }
}