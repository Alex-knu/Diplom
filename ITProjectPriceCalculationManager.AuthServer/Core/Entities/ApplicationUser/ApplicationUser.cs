using Microsoft.AspNetCore.Identity;

namespace ITProjectPriceCalculationManager.AuthServer.Core.Entities.ApplicationUser
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}