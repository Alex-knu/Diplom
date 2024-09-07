using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Infrastructure.Interfaces;
using ITProjectPriceCalculationManager.Infrastructure.Services;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.BelongingFunction;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services;

internal class BelongingFunctionService : BaseService<BelongingFunction, Guid, BelongingFunctionDTO, ITProjectPriceCalculationManagerDbContext>, IBelongingFunctionService
{
    public BelongingFunctionService(IRepository<BelongingFunction, Guid, ITProjectPriceCalculationManagerDbContext> repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<BelongingFunctionDTO> CreateBelongingFunctionAsync(BelongingFunctionDTO BelongingFunction)
    {
        return await base.CreateEntityAsync(BelongingFunction);
    }

    public async Task<BelongingFunctionDTO> DeleteBelongingFunctionAsync(Guid id)
    {
        return await base.DeleteEntityAsync(id);
    }

    public async Task<IEnumerable<BelongingFunctionDTO>> GetBelongingFunctionAsync()
    {
        return await base.GetEntitysAsync();
    }

    public async Task<BelongingFunctionDTO> UpdateBelongingFunctionAsync(BelongingFunctionDTO BelongingFunction)
    {
        return await base.UpdateEntityAsync(BelongingFunction);
    }
}