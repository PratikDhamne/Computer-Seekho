using ComputerSeekho.Models;
using ComputerSeekho.Repository;
using Microsoft.EntityFrameworkCore;

namespace ComputerSeekho.Service
{
    public class ClosureReasonService: IClosureReasonService
    {
        private readonly Appdbcontext _context;

        public ClosureReasonService(Appdbcontext context)
        {
            _context = context;
        }

        public async Task AddClosureReason(ClosureReason closureReason)
        {
            _context.ClosureReasons.Add(closureReason);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClosureReason(ClosureReason closureReason)
        {
            _context.Entry(closureReason).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClosureReason(int id)
        {
            var closureReason = await _context.ClosureReasons.FindAsync(id);
            if (closureReason != null)
            {
                _context.ClosureReasons.Remove(closureReason);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ClosureReason> GetClosureReasonById(int id)
        {
            return await _context.ClosureReasons.FindAsync(id);
        }

        public async Task<IEnumerable<ClosureReason>> GetAllClosureReasons()
        {
            return await _context.ClosureReasons.ToListAsync();
        }
    }
}
