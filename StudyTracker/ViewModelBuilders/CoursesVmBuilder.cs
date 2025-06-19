using StudyTracker.Models;
using StudyTracker.Services;
using StudyTracker.ViewModels;

namespace StudyTracker.ViewModelBuilders
{
    public class CoursesVmBuilder
    {
        private readonly CourseService _courseService;

        public CoursesVmBuilder(CourseService courseService)
        {
            _courseService = courseService;
        }

        public CoursesVm GetCoursesVm()
        {
            var courses = _courseService.GetCourses();
            return new CoursesVm(courses);
        }
    }
}
