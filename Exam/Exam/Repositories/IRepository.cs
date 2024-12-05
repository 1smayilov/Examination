using Exam.Entities;
using System.Linq.Expressions;

namespace Exam.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<TEntity>> GetWithIncludesAsync(params Expression<Func<TEntity, object>>[] includes);
    }
}
