using Exam.Dal.Abstract;
using Exam.Entities;

namespace Exam.Service.Abstract
{
        public interface ILessonService 
        {
            Task<IEnumerable<Lesson>> GetAllAsync();
            Task<Lesson> GetByIdAsync(int id);
            Task AddAsync(Lesson lesson);
            Task UpdateAsync(Lesson lesson);
            Task DeleteAsync(int id);
        }
}
