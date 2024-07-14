using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using ITProjectPriceCalculationManager.AuthServer.Core.DTO;
using ITProjectPriceCalculationManager.AuthServer.Core.Interfaces.Services;
using ITProjectPriceCalculationManager.AuthServer.Core.Models;
using ITProjectPriceCalculationManager.Extentions.Models.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using KeyNotFoundException = ITProjectPriceCalculationManager.Extentions.Models.Exceptions.KeyNotFoundException;
using UnauthorizedAccessException = ITProjectPriceCalculationManager.Extentions.Models.Exceptions.UnauthorizedAccessException;

namespace ITProjectPriceCalculationManager.AuthServer.Core.Services;

public class AuthenticateSevice : IAuthenticateSevice
{
    private readonly IConfiguration _configuration;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<IdentityUser> _userManager;

    public AuthenticateSevice(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager,
        IConfiguration configuration)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
    }

    public async Task<TokenInfoDTO> Login(LoginModel model)
    {
        var user = await _userManager.FindByNameAsync(model.Username);

        if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
        {
            throw new UnauthorizedAccessException("Wrong user credentials!");
        }

        var userRoles = await _userManager.GetRolesAsync(user);

        var authClaims = new List<Claim>
        {
            new("UserIdentifier", user.Id),
            new("UserName", model.Username),
            new("Jti", Guid.NewGuid().ToString())
        };

        if (userRoles.Any())
            authClaims.Add(new Claim("Roles", JsonSerializer.Serialize(userRoles.ToList()),
                JsonClaimValueTypes.JsonArray));

        var token = GetToken(authClaims);

        return new TokenInfoDTO
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = token.ValidTo
        };
    }

    public async Task<string> Register(RegisterModel model)
    {
        var userExists = await _userManager.FindByNameAsync(model.Username);

        if (userExists != null) throw new KeyNotFoundException("User already exists!");

        IdentityUser user = new()
        {
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.Username
        };

        if (!await _roleManager.RoleExistsAsync(UserRoles.User))
        {
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
        }

        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
        {
            throw new BadRequestException("User creation failed! Please check user details and try again.");
        }

        if (await _roleManager.RoleExistsAsync(UserRoles.User))
        {
            await _userManager.AddToRolesAsync(user, new List<string> { UserRoles.User });
        }

        var savedUser = await _userManager.FindByNameAsync(model.Username);

        if (savedUser == null)
        {
            throw new BadRequestException("User creation failed! Please check user details and try again.");
        }

        return savedUser.Id;
    }

    public async Task RegisterAdmin(RegisterModel model)
    {
        var userExists = await _userManager.FindByNameAsync(model.Username);

        if (userExists != null)
        {
            throw new BadRequestException("User already exists!");
        }

        IdentityUser user = new()
        {
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.Username
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
        {
            throw new BadRequestException("User creation failed! Please check user details and try again.");
        }

        if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
        {
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        }

        if (!await _roleManager.RoleExistsAsync(UserRoles.User))
        {
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
        }

        if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
        {
            await _userManager.AddToRolesAsync(user, new List<string> { UserRoles.Admin, UserRoles.User });
        }
    }

    private JwtSecurityToken GetToken(List<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Secret"] ?? string.Empty));

        var token = new JwtSecurityToken(
            _configuration["ValidIssuer"],
            _configuration["ValidAudience"],
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        return token;
    }
}