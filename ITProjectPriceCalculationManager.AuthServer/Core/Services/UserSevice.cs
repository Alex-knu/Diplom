using ITProjectPriceCalculationManager.AuthServer.Core.DTO;
using ITProjectPriceCalculationManager.AuthServer.Core.Interfaces.Services;
using ITProjectPriceCalculationManager.AuthServer.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

        public IEnumerable<string> GetAllUserIdsByRole(string roleName)
        {
            return (from user in _dbContext.Users
                    join userRole in _dbContext.UserRoles on user.Id equals userRole.UserId
                    join role in _dbContext.Roles on userRole.RoleId equals role.Id
                    where role.Name == roleName
                    select user.Id).ToList();
        }

        public async Task<UserDTO> UpdateUserRoles(UserDTO query)
        {
            var selectedRoleIds = query.Roles.Select(r => r.Id.ToString());
            var currentUserRolesIds = _dbContext.UserRoles.AsNoTracking().Where(ur => ur.UserId == query.Id.ToString()).ToList().Select(ur => ur.RoleId.ToString());

            foreach (var userRole in currentUserRolesIds.Except(selectedRoleIds))
            {
                _dbContext.UserRoles.Remove(new IdentityUserRole<string>()
                {
                    UserId = query.Id.ToString(),
                    RoleId = userRole
                });
            }

            foreach (var roleId in selectedRoleIds.Except(currentUserRolesIds))
            {
                _dbContext.UserRoles.Add(new IdentityUserRole<string>()
                {
                    UserId = query.Id.ToString(),
                    RoleId = roleId
                });
            }

            await _dbContext.SaveChangesAsync();

            return query;
        }
    }
}