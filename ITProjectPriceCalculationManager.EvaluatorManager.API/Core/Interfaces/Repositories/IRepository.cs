using System.Linq.Expressions;
using Ardalis.Specification;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces.Repositories;

internal interface IRepository<TEntity, TKey> where TEntity : class, IBaseEntity<TKey>
{
    Task<TEntity> AddAsync(TEntity entity);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByKeyAsync(TKey key);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> DeleteAsync(TEntity entity);
    Task DeleteRangeAsync(IEnumerable<TEntity> entities);
    IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes);
    Task<int> SaveChangesAcync();
    Task<List<TEntity>> AddRangeAsync(List<TEntity> entities);
    Task<IEnumerable<TEntity>> GetListBySpecAsync(ISpecification<TEntity> specification);
    Task<TEntity?> GetFirstBySpecAsync(ISpecification<TEntity> specification);
    Task<List<TEntity>> ExecuteStoredProcedure(FormattableString query);
}