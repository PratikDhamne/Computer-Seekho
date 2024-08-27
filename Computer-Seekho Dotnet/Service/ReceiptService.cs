using ComputerSeekho.Models;
using ComputerSeekho.Repository;
using Microsoft.EntityFrameworkCore;

namespace ComputerSeekho.Service
{
    public class ReceiptService:IReceiptService
    {
        private readonly Appdbcontext _context;

        public ReceiptService(Appdbcontext context)
        {
            _context = context;
        }

        public async Task AddReceipt(Receipt receipt)
        {
            _context.Receipt.Add(receipt);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReceipt(int id)
        {
            var receipt = await _context.Receipt.FindAsync(id);
            if (receipt != null)
            {
                _context.Receipt.Remove(receipt);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Receipt> GetReceiptById(int id)
        {
            return await _context.Receipt.FindAsync(id);
        }

        public async Task<IEnumerable<Receipt>> GetAllReceipts()
        {
            return await _context.Receipt.ToListAsync();
        }

        public async Task UpdateReceipt(Receipt receipt)
        {
            _context.Entry(receipt).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
