using ITProjectPriceCalculationManager.AuthServer.Core.DTO;
using ITProjectPriceCalculationManager.AuthServer.Core.Interfaces.Services;
using ITProjectPriceCalculationManager.AuthServer.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace ITProjectPriceCalculationManager.AuthServer.Core.Services
{
    public class UserSevice : IUserSevice
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public UserSevice(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            return (from user in _dbContext.Users
                    select new UserDTO()
                    {
                        Id = new Guid(user.Id),
                        Name = user.UserName,
                        Roles = (from userRole in _dbContext.UserRoles
                                 join role in _dbContext.Roles on userRole.RoleId equals role.Id
                                 where userRole.UserId == user.Id
                                 select new RoleDTO()
                                 {
                                     Id = new Guid(role.Id),
                                     Name = role.Name
                                 }).ToList()
                    }).ToList();
        }

        public async Task<UserDTO> UpdateUserRoles(UserDTO query)
        {
            var selectedRoleIds = query.Roles.Select(r => r.Id.ToString());

            foreach (var userRole in _dbContext.UserRoles.Where(ur => ur.UserId == query.Id.ToString()))
            {
                if (!selectedRoleIds.Contains(userRole.RoleId))
                {
                    _dbContext.UserRoles.Remove(userRole);
                }
            }

            foreach (var roleId in selectedRoleIds)
            {
                if (_dbContext.UserRoles.Where(ur => ur.UserId == query.Id.ToString() && ur.RoleId == roleId).FirstOrDefault() == null)
                {
                    _dbContext.UserRoles.Add(new IdentityUserRole<string>()
                    {
                        UserId = query.Id.ToString(),
                        RoleId = roleId
                    });
                }
            }

            await _dbContext.SaveChangesAsync();

            return query;
        }
    }
}