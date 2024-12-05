using Exam.Dal.Abstract;
using Exam.Entities;
using Exam.Repositories;
using Exam.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{

    namespace Exam.Controllers
    {
        public class StudentController : Controller
        {
            private readonly IStudentService _studentService;

            public StudentController(IStudentService studentService)
            {
                _studentService = studentService;
            }

            public async Task<IActionResult> Index()
            {
                var students = await _studentService.GetAllAsync();
                return View(students);
            }


            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Create(Student student)
            {
                    await _studentService.AddAsync(student);
                    return RedirectToAction(nameof(Index));
            }

            public async Task<IActionResult> Edit(int id)
            {
                var student = await _studentService.GetByIdAsync(id);
                if (student == null)
                {
                    return NotFound();
                }
                return View(student);
            }

            [HttpPost]
            public async Task<IActionResult> Edit(int id, Student student)
            {
                if (id != student.Id)
                {
                    return NotFound();
                }

                    await _studentService.UpdateAsync(student);
                    return RedirectToAction(nameof(Index));
            }

            

            [HttpPost("Delete")]
            public async Task<IActionResult> Delete(int id)
            {
                var student = await _studentService.GetByIdAsync(id);
                if (student == null)
                {
                    return NotFound();
                }
                await _studentService.DeleteAsync(id);  
                return RedirectToAction(nameof(Index)); 
            }
        }
    }

}
