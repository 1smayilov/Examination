using Exam.Context;
using Exam.Dal.Abstract;
using Exam.Entities;
using Exam.Repositories;

namespace Exam.Dal.Concrete
{
    public class StudentDal : RepositoryBase<Student>, IStudentDal
    {
        public StudentDal(AppDbContext context) : base(context)
        {
        }
    }
}
