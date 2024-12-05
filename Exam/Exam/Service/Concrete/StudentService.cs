using Exam.Dal.Abstract;
using Exam.Entities;
using Exam.Service.Abstract;

namespace Exam.Service.Concrete
{
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

