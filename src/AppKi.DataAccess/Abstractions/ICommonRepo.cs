using System.Linq.Expressions;

namespace AppKi.DataAccess.Abstractions;

public interface ICommonRepo<TEntity, in TIdentifiable> where TEntity : IIdentifiable<TIdentifiable>
{
    Task Add(TEntity entity);
    Task Update(TEntity entity);
    Task Update(TEntity entity, Expression<Func<TEntity, bool>> predicate);
    Task Delete(TIdentifiable id);
    Task Delete(Expression<Func<TEntity, bool>> predicate);
    Task<bool> Any(Expression<Func<TEntity, bool>> predicate);
    
    Task<TEntity> Get(TIdentifiable id);
    Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
    
    Task<IReadOnlyList<TEntity>> GetMany(Expression<Func<TEntity, bool>> predicate);
    Task<IReadOnlyList<T>> GetMany<T>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, T>> selector);
    
    Task<(int total, IReadOnlyList<TEntity> data)> GetPaged<T>(
        int page, int count,
        Expression<Func<TEntity, bool>> predicate, 
        Expression<Func<TEntity, object>> sort, 
        bool desc = true,
        Expression<Func<TEntity, T>> selector = null);
}