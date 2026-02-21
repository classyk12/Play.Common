using System.Linq.Expressions;
using Play.Common.Common;
namespace Play.Common
{
    public interface IRepository<T> where T : IEntity
    {
        Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<T?> GetAsync(Expression<Func<T, bool>> filter);
        Task<T?> GetAsync(Guid id);
        Task CreateAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(Guid id);
    }
}