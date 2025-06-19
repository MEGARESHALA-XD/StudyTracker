using Microsoft.AspNetCore.Mvc;
using StudyTracker.Models;
using StudyTracker.Services;
using StudyTracker.ViewModelBuilders;

namespace StudyTracker.Controllers
{
    public class CourseController : Controller
    {
        private readonly CoursesVmBuilder _coursesVmBuilder;
        private readonly CourseService _courseService;

        public CourseController(CourseService courseService
            , CoursesVmBuilder coursesVmBuilder)
        {
            _coursesVmBuilder = coursesVmBuilder;
            _courseService = courseService;
        }

        // GET: CourseController
        public ActionResult Index()
        {
            var coursesVm = _coursesVmBuilder.GetCoursesVm();
            return View(coursesVm);
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Name,Description,ProfessorName")] Course course)
        {
            try
            {
                _courseService.AddCourse(course);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(course);
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            var course = _courseService.GetCourses().FirstOrDefault(c => c.Id == id);
            if (course == null)
                return NotFound();

            return View(course);
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Name,Description,ProfessorName")] Course updatedCourse)
        {
            try
            {
                var existing = _courseService.GetCourses().FirstOrDefault(c => c.Id == id);
                if (existing == null)
                    return NotFound();

                existing.Name = updatedCourse.Name;
                existing.Description = updatedCourse.Description;
                existing.ProfessorName = updatedCourse.ProfessorName;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(updatedCourse);
            }
        }

        // GET: CourseController/Delete/5
        public ActionResult Delete(int id)
        {
            _courseService.RemoveCourse(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}