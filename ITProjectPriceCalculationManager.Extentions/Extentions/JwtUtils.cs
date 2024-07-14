using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ITProjectPriceCalculationManager.Extentions.Models;
using ITProjectPriceCalculationManager.Extentions.Models.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace ITProjectPriceCalculationManager.Extentions.Extentions;

public static class JwtUtils
{
    public static string? SecretKey { get; set; }

    public static UserInfo GetUserInfo(HttpContext httpContext)
    {
        if (string.IsNullOrEmpty(SecretKey))
        {
            throw new BadRequestException("Configs not contains keys");
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenHeader = httpContext.Request.Headers["Authorization"];

        if (!tokenHeader.ToString().StartsWith("Bearer "))
        {
            throw new BadRequestException("Invalid token");
        }

        var token = tokenHeader.ToString().Substring(7);
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };

        try
        {
            var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out var securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurityToken ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return new UserInfo
            {
                UserId = new Guid(claimsPrincipal.FindFirstValue("UserIdentifier") ?? string.Empty),
                UserName = claimsPrincipal.FindFirstValue("UserName") ?? string.Empty,
                Roles = claimsPrincipal.FindAll("Roles").Select(c => c.Value).ToList()
            };
        }
        catch
        {
            throw new BadRequestException("Invalid token");
        }
    }
}