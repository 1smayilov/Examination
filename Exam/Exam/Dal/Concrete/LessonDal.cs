using Exam.Context;
using Exam.Dal.Abstract;
using Exam.Entities;
using Exam.Repositories;

namespace Exam.Dal.Concrete
{
    public class LessonDal : RepositoryBase<Lesson>, ILessonDal
    {
        public LessonDal(AppDbContext context) : base(context)
        {
        }
    }
}
