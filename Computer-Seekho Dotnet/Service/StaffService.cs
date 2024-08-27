using ComputerSeekho.Models;
using ComputerSeekho.Repository;
using Microsoft.EntityFrameworkCore;

namespace ComputerSeekho.Service
{
    public class StaffService:IStaffService
    {
        private readonly Appdbcontext _context;

        public StaffService(Appdbcontext context)
        {
            _context = context;
        }

        public async Task AddStaff(Staff staff)
        {
            _context.Staffs.Add(staff);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStaff(int id)
        {
            var staff = await _context.Staffs.FindAsync(id);
            if (staff != null)
            {
                _context.Staffs.Remove(staff);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Staff> GetStaffById(int id)
        {
            return await _context.Staffs.FindAsync(id);
        }

        public async Task<IEnumerable<Staff>> GetAllStaff()
        {
            return await _context.Staffs.ToListAsync();
        }

        public async Task UpdateStaff(Staff staff)
        {
            _context.Entry(staff).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<Staff> GetStaffByUsername(string username)
        {
            return await _context.Staffs.FirstOrDefaultAsync(s => s.StaffUsername == username);
        }
        public async Task<Staff> GetStaffByUsernameAndPassword(string username, string password)
        {
            return await _context.Staffs
                .FirstOrDefaultAsync(s => s.StaffUsername == username && s.StaffPassword == password);
        }

    }
}
