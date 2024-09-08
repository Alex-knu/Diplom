using AutoMapper;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Department;
using ITProjectPriceCalculationManager.Infrastructure.Interfaces;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data;
using ITProjectPriceCalculationManager.Infrastructure.Services;
using ITProjectPriceCalculationManager.DTOModels.DTO.ITProjectsManager;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services;

internal class DepartmentTreeService : BaseService<Department, Guid, DepartmentDTO, ITProjectPriceCalculationManagerDbContext>, IDepartmentTreeService
{
    public DepartmentTreeService(IRepository<Department, Guid, ITProjectPriceCalculationManagerDbContext> repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<IEnumerable<DepartmentDTO>> GetDepartmentsTreeAsync()
    {
        return await base.GetEntityListBySpecAsync(new Departments.DepartmentsTree());
    }
}