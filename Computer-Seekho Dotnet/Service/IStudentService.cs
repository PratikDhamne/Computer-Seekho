using ComputerSeekho.Models;

namespace ComputerSeekho.Service
{
    public interface IStudentService
    {
        Task AddStudent(Student student);
        Task DeleteStudent(int id);
        Task<Student> GetStudentById(int id);
        Task<IEnumerable<Student>> GetAllStudents();
        Task UpdateStudent(Student student);
    }
}
