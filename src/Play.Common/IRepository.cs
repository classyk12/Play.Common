using System.Linq.Expressions;
using Play.Common.Common;
namespace Play.Common
{
    public interface IRepository<T> where T : IEntity
    {
        Task CreateItemAsync(T item);
        Task<T?> GetAsync(Expression<Func<T, bool>> filter);
        Task<T?> GetAsync(Guid id);
        Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task UpdateItemAsync(T item);
        Task DeleteItemAsync(Guid id);
    }
}