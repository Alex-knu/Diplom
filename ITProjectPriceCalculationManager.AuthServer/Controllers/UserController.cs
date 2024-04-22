using ITProjectPriceCalculationManager.AuthServer.Core.DTO;
using ITProjectPriceCalculationManager.AuthServer.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.AuthServer.Controllers;

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

    [HttpGet]
    [Route("{roleName}")]
    public IActionResult GetAllUsers([FromRoute] string roleName)
    {
        return Ok(_userSevice.GetAllUserIdsByRole(roleName));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUserRoles(UserDTO query)
    {
        return Ok(await _userSevice.UpdateUserRoles(query));
    }
}