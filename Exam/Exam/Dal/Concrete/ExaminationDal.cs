using Exam.Context;
using Exam.Dal.Abstract;
using Exam.Entities;
using Exam.Repositories;

namespace Exam.Dal.Concrete
{
    public class ExaminationDal : RepositoryBase<Examination>, IExaminationDal
    {
        public ExaminationDal(AppDbContext context) : base(context)
        {
        }
    }
}
