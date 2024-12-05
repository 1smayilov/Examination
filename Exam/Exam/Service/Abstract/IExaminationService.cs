using Exam.Entities;
using System.Linq.Expressions;

namespace Exam.Services.Abstract
{
    public interface IExaminationService
    {
        Task<IEnumerable<Examination>> GetAllAsync();
        Task<Examination> GetByIdAsync(int id);
        Task AddAsync(Examination examination);
        Task UpdateAsync(Examination examination);
        Task DeleteAsync(int id);
        Task<IEnumerable<Examination>> GetWithIncludesAsync(params Expression<Func<Examination, object>>[] includes);
    }
}
