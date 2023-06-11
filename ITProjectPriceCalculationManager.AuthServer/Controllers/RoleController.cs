using ITProjectPriceCalculationManager.AuthServer.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.AuthServer.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleSevice _roleSevice;

        public RoleController(IRoleSevice roleSevice)
        {
            _roleSevice = roleSevice;
        }

        
        [HttpGet]
        [Route("collection")]
        public IActionResult GetAllRoles()
        {
            return Ok(_roleSevice.GetAllRoles());
        }
    }
}