using System.Linq.Expressions;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using ITProjectPriceCalculationManager.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ITProjectPriceCalculationManager.Infrastructure.Repositories;

public class BaseRepository<TEntity, TKey, TDbContext> : IRepository<TEntity, TKey,TDbContext>
    where TEntity : class, IBaseEntity<TKey>
    where TDbContext : DbContext
{
    protected readonly TDbContext _dbContext;
    protected readonly DbSet<TEntity> _dbSet;

    public BaseRepository(TDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TEntity>();
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public async Task<List<TEntity>> AddRangeAsync(List<TEntity> entities)
    {
        await _dbSet.AddRangeAsync(entities);
        return entities;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        await Task.Run(() => _dbSet.Remove(entity));
        return entity;
    }

    public async Task DeleteRangeAsync(IEnumerable<TEntity> entities)
    {
        await Task.Run(() => _dbSet.RemoveRange(entities));
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<TEntity?> GetByKeyAsync(TKey key)
    {
        return await _dbSet.FindAsync(key);
    }

    public IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes)
    {
        var query = includes
            .Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>(_dbSet,
                (current, include) => current.Include(include));

        return query;
    }

    public async Task<int> SaveChangesAcync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        await Task.Run(() => _dbContext.Entry(entity).State = EntityState.Modified);
        return entity;
    }

    public async Task<IEnumerable<TEntity>> GetListBySpecAsync(ISpecification<TEntity> specification)
    {
        return await ApplySpecification(specification).ToListAsync();
    }

    public async Task<TEntity?> GetFirstBySpecAsync(ISpecification<TEntity> specification)
    {
        return await ApplySpecification(specification).FirstOrDefaultAsync();
    }

    public async Task<List<TEntity>> ExecuteStoredProcedure(FormattableString query)
    {
        return await _dbSet.FromSqlInterpolated(query).ToListAsync();
    }

    private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specification)
    {
        var evaluator = new SpecificationEvaluator();
        return evaluator.GetQuery(_dbSet, specification);
    }
}