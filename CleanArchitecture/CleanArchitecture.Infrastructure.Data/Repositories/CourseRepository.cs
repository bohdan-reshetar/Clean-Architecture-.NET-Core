using System.Collections.Generic;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Infrastructure.Data.Context;

namespace CleanArchitecture.Infrastructure.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly UniversityDbContext _universityDbContext;

        public CourseRepository(UniversityDbContext universityDbContext)
        {
            _universityDbContext = universityDbContext;
        }

        public void Add(Course course)
        {
            _universityDbContext.Courses.Add(course);
            _universityDbContext.SaveChanges();
        }

        public IEnumerable<Course> GetCourses()
        {
            return _universityDbContext.Courses;
        }
    }
}