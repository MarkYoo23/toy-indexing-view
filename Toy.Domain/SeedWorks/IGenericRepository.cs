using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Toy.Domain.SeedWorks;

public interface IGenericRepository<T> : IRepository<T> where T : Entity
{
    EntityEntry<T> Add(T entity);
    Task<EntityEntry<T>> AddAsync(T entity);
    void AddRange(IEnumerable<T> entities);
    Task AddRangeAsync(IEnumerable<T> entities);
    
    IEnumerable<T> FindAll(Expression<Func<T, bool>> expression);
    Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> expression);
    IEnumerable<T> FindAsNoTracking(Expression<Func<T, bool>> expression);
    Task<IEnumerable<T>> FindAsNoTrackingAsync(Expression<Func<T, bool>> expression);
    T FindSingle(Expression<Func<T, bool>> expression);
    Task<T> FindSingleAsync(Expression<Func<T, bool>> expression);
    
    IEnumerable<T> GetAll();
    Task<IEnumerable<T>> GetAllAsync();
    IEnumerable<T> GetAllAsNoTracking();
    Task<IEnumerable<T>> GetAllAsNoTrackingAsync();
    Task<T?> GetByIdAsync(int id);
    
    public EntityEntry<T> Update(T entity);
    void UpdateRange(IEnumerable<T> entities);
    
    EntityEntry<T> Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    
    int GetTotalCount();
    int GetTotalCount(Expression<Func<T, bool>> expression);
    Task<int> GetTotalCountAsync();
    Task<int> GetTotalCountAsync(Expression<Func<T, bool>> expression);

}
