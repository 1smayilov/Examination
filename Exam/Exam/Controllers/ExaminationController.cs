using Exam.Entities;
using Exam.Service.Abstract;
using Exam.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Exam.Controllers
{
    public class ExaminationController : Controller
    {
        private readonly IExaminationService _examinationService;
        private readonly ILessonService _lessonService;
        private readonly IStudentService _studentService;

        public ExaminationController(IExaminationService examinationService, ILessonService lessonService, IStudentService studentService)
        {
            _examinationService = examinationService;
            _lessonService = lessonService;
            _studentService = studentService;
        }

        public async Task<IActionResult> Index()
        {
            var examinations = await _examinationService.GetWithIncludesAsync(
                x => x.Lesson,
                x => x.Student
            );

            return View(examinations);
        }

        public async Task<IActionResult> Create()
        {
            var lessons = await _lessonService.GetAllAsync();
            var students = await _studentService.GetAllAsync();

            ViewData["Lessons"] = new SelectList(lessons, "LessonId", "Name");
            ViewData["Students"] = new SelectList(students, "Id", "FirstName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Examination examination)
        {
            await _examinationService.AddAsync(examination);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var examination = await _examinationService.GetByIdAsync(id);
            if (examination == null)
            {
                return NotFound();
            }

            var lessons = await _lessonService.GetAllAsync();
            ViewData["Lessons"] = lessons
                .Select(lesson => new SelectListItem
                {
                    Value = lesson.LessonId.ToString(),
                    Text = lesson.Name
                }).ToList();

            var students = await _studentService.GetAllAsync();
            ViewData["Students"] = students
                .Select(student => new SelectListItem
                {
                    Value = student.Id.ToString(),
                    Text = student.FirstName
                }).ToList();

            return View(examination);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Examination examination)
        {
            if (id != examination.Id)
            {
                return NotFound();
            }

                await _examinationService.UpdateAsync(examination);
                return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var examination = await _examinationService.GetByIdAsync(id);
            if (examination == null)
            {
                return NotFound();
            }
            await _examinationService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
