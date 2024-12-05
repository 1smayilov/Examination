using Exam.Entities;
using Exam.Service.Abstract;
using Exam.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
    public class LessonController : Controller
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        public async Task<IActionResult> Index()
        {
            var lessons = await _lessonService.GetAllAsync();
            return View(lessons);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Lesson lesson)
        {
                await _lessonService.AddAsync(lesson);
                return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var lesson = await _lessonService.GetByIdAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }
            return View(lesson);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Lesson lesson)
        {
            if (id != lesson.LessonId)
            {
                return NotFound();
            }

                await _lessonService.UpdateAsync(lesson);
                return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var lesson = await _lessonService.GetByIdAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }
            await _lessonService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
