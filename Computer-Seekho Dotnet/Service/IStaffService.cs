using ComputerSeekho.Models;

namespace ComputerSeekho.Service
{
    public interface IStaffService
    {
        Task AddStaff(Staff staff);
        Task DeleteStaff(int id);
        Task<Staff> GetStaffById(int id);
        Task<IEnumerable<Staff>> GetAllStaff();
        Task UpdateStaff(Staff staff);
        Task<Staff> GetStaffByUsername(string username);
        Task<Staff> GetStaffByUsernameAndPassword(string username, string password);

    }
}
