using CleanArchitecture.Application.ViewModels;
using System.Collections.Generic;

namespace CleanArchitecture.Application.Interfaces
{
    interface ICourseService
    {
        CourseViewModel GetCourses();
    }
}
