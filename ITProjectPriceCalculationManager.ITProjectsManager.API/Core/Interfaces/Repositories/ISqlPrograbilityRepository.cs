using Microsoft.Data.SqlClient;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Repositories
{
    internal interface ISqlPrograbilityRepository<TEntity, TKey> where TEntity : class, IBaseEntity<TKey>
    {
        IEnumerable<TEntity> ExecuteStoredProcedureAsync(string procedureName, SqlParameter[] parameters);
    }
}