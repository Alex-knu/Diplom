using Ardalis.Specification;
using AutoMapper;
using ITProjectPriceCalculationManager.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ITProjectPriceCalculationManager.Infrastructure.Services;

public abstract class BaseService<TEntity, TKey, TResult, TDbContext>
    where TEntity : class, IBaseEntity<TKey>
    where TDbContext : DbContext
{
    protected readonly IMapper _mapper;
    protected readonly IRepository<TEntity, TKey, TDbContext> _repository;

    public BaseService(IRepository<TEntity, TKey, TDbContext> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    protected virtual async Task<TResult> CreateEntityAsync(TResult entityDTO)
    {
        try
        {
            var domainEntity = _mapper.Map<TEntity>(entityDTO);
            var newDomainEntity = await _repository.AddAsync(domainEntity);
            await _repository.SaveChangesAcync();

            return _mapper.Map<TResult>(newDomainEntity);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected virtual async Task<TResult> DeleteEntityAsync(TKey id)
    {
        var domainEntity = await _repository.GetByKeyAsync(id);

        if (domainEntity == null)
        {
            throw new BadHttpRequestException("Entity not found");
        }

        var deleteDomainEntity = await _repository.DeleteAsync(domainEntity);
        await _repository.SaveChangesAcync();

        return _mapper.Map<TResult>(deleteDomainEntity);
    }

    protected virtual async Task<IEnumerable<TResult>> GetEntitysAsync()
    {
        var domainEntity = await _repository.GetAllAsync();

        return _mapper.Map<IEnumerable<TResult>>(domainEntity);
    }

    protected virtual async Task<IEnumerable<TResult>> GetEntityListBySpecAsync(Specification<TEntity> specification)
    {
        var domainEntity = await _repository.GetListBySpecAsync(specification);

        return _mapper.Map<IEnumerable<TResult>>(domainEntity);
    }

    protected virtual async Task<TResult> GetEntitysByIdAsync(TKey id)
    {
        var domainEntity = await _repository.GetByKeyAsync(id);

        return _mapper.Map<TResult>(domainEntity);
    }

    protected virtual async Task<TResult> UpdateEntityAsync(TResult entityDTO)
    {
        try
        {
            var domainEntity = _mapper.Map<TEntity>(entityDTO);

            var updateDomainEntity = await _repository.UpdateAsync(domainEntity);
            await _repository.SaveChangesAcync();

            return _mapper.Map<TResult>(updateDomainEntity);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
