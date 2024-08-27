using ComputerSeekho.Models;
using ComputerSeekho.Repository;
using Microsoft.EntityFrameworkCore;

namespace ComputerSeekho.Service
{
    public class FollowupService: IFollowupService
    {
        private readonly Appdbcontext _context;

        public FollowupService(Appdbcontext context)
        {
            _context = context;
        }

        public async Task AddFollowup(Followup followup)
        {
            _context.Followups.Add(followup);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFollowup(int id)
        {
            var followup = await _context.Followups.FindAsync(id);
            if (followup != null)
            {
                _context.Followups.Remove(followup);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Followup> GetFollowupById(int id)
        {
            return await _context.Followups.FindAsync(id);
        }

        public async Task<IEnumerable<Followup>> GetAllFollowups()
        {
            return await _context.Followups.ToListAsync();
        }

        public async Task UpdateFollowup(Followup followup)
        {
            _context.Entry(followup).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
