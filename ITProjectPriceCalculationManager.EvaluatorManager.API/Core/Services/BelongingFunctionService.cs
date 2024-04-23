using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.BelongingFunction;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces.Repositories;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces.Services;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Services;

internal class BelongingFunctionService : BaseService<BelongingFunction, Guid, BelongingFunctionDTO>, IBelongingFunctionService
{
    public BelongingFunctionService(IRepository<BelongingFunction, Guid> repository, IMapper mapper) : base(repository, mapper)
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

    public Task<BelongingFunctionDTO> GetBelongingFunctionByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<BelongingFunctionDTO>> GetBelongingFunctionAsync()
    {
        return await base.GetEntitysAsync();
    }

    public async Task<BelongingFunctionDTO> GetBelongingFunctionsByIdAsync(Guid id)
    {
        return await base.GetEntitysByIdAsync(id);
    }

    public async Task<BelongingFunctionDTO> UpdateBelongingFunctionAsync(BelongingFunctionDTO BelongingFunction)
    {
        return await base.UpdateEntityAsync(BelongingFunction);
    }
}