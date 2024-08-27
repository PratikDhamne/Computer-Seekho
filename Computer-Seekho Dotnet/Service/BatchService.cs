using ComputerSeekho.Models;
using ComputerSeekho.Repository;
using Microsoft.EntityFrameworkCore;

namespace ComputerSeekho.Service
{
    public class BatchService : IBatchService
    {
        private readonly Appdbcontext _context;

        public BatchService(Appdbcontext context)
        {
            _context = context;
        }

        public async Task AddBatch(Batch batch)
        {
            _context.Batches.Add(batch);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBatch(Batch batch)
        {
            _context.Entry(batch).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBatch(int id)
        {
            var batch = await _context.Batches.FindAsync(id);
            if (batch != null)
            {
                _context.Batches.Remove(batch);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Batch> GetBatchById(int id)
        {
            return await _context.Batches.FindAsync(id);
        }

        public async Task<IEnumerable<Batch>> GetAllBatches()
        {
            return await _context.Batches.ToListAsync();
        }
        public async Task<IEnumerable<Batch>> GetBatchByName(string batchName)
        {
            return await _context.Batches
                .Where(b => b.BatchName.Contains(batchName))
                .ToListAsync();
        }
        public async Task<IEnumerable<Batch>> GetBatchByCourseId(int courseId)
        {
            return await _context.Batches
                .Where(b => b.CourseId == courseId)
                .ToListAsync();
        }
    }

}
