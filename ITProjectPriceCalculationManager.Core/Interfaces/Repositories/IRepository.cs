using Ardalis.Specification;
using System.Linq.Expressions;

namespace ITProjectPriceCalculationManager.Core.Interfaces.Repositories
{
    public interface IRepository<TEntity, TKey> where TEntity : class, IBaseEntity<TKey>
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByKeyAsync(TKey key);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);
        Task DeleteRangeAsync(IEnumerable<TEntity> entities);
        IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes);
        Task<int> SaveChangesAcync();
        Task AddRangeAsync(List<TEntity> entities);
        Task<IEnumerable<TEntity>> GetListBySpecAsync(ISpecification<TEntity> specification);
        Task<TEntity?> GetFirstBySpecAsync(ISpecification<TEntity> specification);
    }
}