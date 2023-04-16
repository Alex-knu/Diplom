using System.Security.Claims;
using ITProjectPriceCalculationManager.AuthServer.Core.Entities.ApplicationUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using IdentityModel;

namespace ITProjectPriceCalculationManager.AuthServer.Core.Factories
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser>
    {
        public ApplicationUserClaimsPrincipalFactory(UserManager<ApplicationUser> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var claimsIdentity = await base.GenerateClaimsAsync(user);

            if(string.IsNullOrEmpty(user.FirstName))
            {
                claimsIdentity.AddClaim(new Claim(JwtClaimTypes.GivenName, user.FirstName));
            }

            if(string.IsNullOrEmpty(user.LastName))
            {
                claimsIdentity.AddClaim(new Claim(JwtClaimTypes.FamilyName, user.LastName));
            }

            return claimsIdentity;
        }
    }
}