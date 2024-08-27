using ComputerSeekho.Models;

namespace ComputerSeekho.Service
{
    public interface ICourseService
    {
        Task AddCourse(Course course);
        Task UpdateCourse(Course course);
        Task DeleteCourse(int id);
        Task<Course> GetCourseById(int id);
        Task<IEnumerable<Course>> GetAllCourses();
    }
}
