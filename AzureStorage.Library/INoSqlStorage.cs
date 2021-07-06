using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AzureStorage.Library
{
    public interface INoSqlStorage<TEntity>
    {
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Get(string rowKey, string partitionKey);
        Task Delete(string rowKey, string partitionKey);
        Task<TEntity> Update(TEntity entity);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Query(Expression<Func<TEntity,bool>> query);
    }
}
