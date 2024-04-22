using ITProjectPriceCalculationManager.AuthServer.Core.DTO;
using ITProjectPriceCalculationManager.AuthServer.Core.Interfaces.Services;
using ITProjectPriceCalculationManager.AuthServer.Infrastructure;

namespace ITProjectPriceCalculationManager.AuthServer.Core.Services;

public class RoleSevice : IRoleSevice
{
    private readonly IConfiguration _configuration;
    protected readonly ApplicationDbContext _dbContext;

    public RoleSevice(ApplicationDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration = configuration;
    }

    public IEnumerable<RoleDTO> GetAllRoles()
    {
        return (from role in _dbContext.Roles
            select new RoleDTO
            {
                Id = new Guid(role.Id),
                Name = role.Name
            }).ToList();
    }
}