using Exam.Dal.Abstract;
using Exam.Entities;
using Exam.Service.Abstract;

namespace Exam.Services.Concrete
{
    public class LessonService : ILessonService
    {
        private readonly ILessonDal _lessonDal;

        public LessonService(ILessonDal lessonDal)
        {
            _lessonDal = lessonDal;
        }

        public async Task<IEnumerable<Lesson>> GetAllAsync()
        {
            return await _lessonDal.GetAllAsync();
        }

        public async Task<Lesson> GetByIdAsync(int id)
        {
            return await _lessonDal.GetByIdAsync(id);
        }

        public async Task AddAsync(Lesson lesson)
        {
            await _lessonDal.AddAsync(lesson);
        }

        public async Task UpdateAsync(Lesson lesson)
        {
            await _lessonDal.UpdateAsync(lesson);
        }

        public async Task DeleteAsync(int id)
        {
            await _lessonDal.DeleteAsync(id);
        }
    }

    public class StudentService : IStudentService
    {
        private readonly IStudentDal _studentDal;

        public StudentService(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _studentDal.GetAllAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _studentDal.GetByIdAsync(id);
        }

        public async Task AddAsync(Student student)
        {
            await _studentDal.AddAsync(student);
        }

        public async Task UpdateAsync(Student student)
        {
            await _studentDal.UpdateAsync(student);
        }

        public async Task DeleteAsync(int id)
        {
            await _studentDal.DeleteAsync(id);
        }
    }
}
