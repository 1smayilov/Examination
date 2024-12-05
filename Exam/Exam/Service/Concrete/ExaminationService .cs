using Exam.Dal.Abstract;
using Exam.Entities;
using Exam.Services.Abstract;
using System.Linq.Expressions;

namespace Exam.Services.Concrete
{
    public class ExaminationService : IExaminationService
    {
        private readonly IExaminationDal _examinationDal;

        public ExaminationService(IExaminationDal examinationDal)
        {
            _examinationDal = examinationDal;
        }

        public async Task<IEnumerable<Examination>> GetAllAsync()
        {
            return await _examinationDal.GetAllAsync();
        }

        public async Task<Examination> GetByIdAsync(int id)
        {
            return await _examinationDal.GetByIdAsync(id);
        }

        public async Task AddAsync(Examination examination)
        {
            await _examinationDal.AddAsync(examination);
        }

        public async Task UpdateAsync(Examination examination)
        {
            await _examinationDal.UpdateAsync(examination);
        }

        public async Task DeleteAsync(int id)
        {
            await _examinationDal.DeleteAsync(id);
        }

        public async Task<IEnumerable<Examination>> GetWithIncludesAsync(params Expression<Func<Examination, object>>[] includes)
        {
            return await _examinationDal.GetWithIncludesAsync(includes);
        }
    }
}
