using System.Linq.Expressions;
using AppKi.DataAccess.Abstractions;

namespace AppKi.DataAccess.Repositories.Internals;

internal class _MongoRepo<TEntity, TIdentifiable> : ICommonRepo<TEntity, TIdentifiable>
    where TEntity : IIdentifiable<TIdentifiable>
{
    public _MongoRepo()
    {
        
    }
    
    public Task Add(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(TEntity entity, Expression<Func<TEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task Delete(TIdentifiable id)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Expression<Func<TEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Any(Expression<Func<TEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> Get(TIdentifiable id)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<TEntity>> GetMany(Expression<Func<TEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<T>> GetMany<T>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, T>> selector)
    {
        throw new NotImplementedException();
    }

    public Task<(int total, IReadOnlyList<TEntity> data)> GetPaged<T>(
        int page, int count, 
        Expression<Func<TEntity, bool>> predicate, 
        Expression<Func<TEntity, object>> sort,
        bool desc = true, 
        Expression<Func<TEntity, T>> selector = null)
    {
        throw new NotImplementedException();
    }
}