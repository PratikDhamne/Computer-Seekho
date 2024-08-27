using ComputerSeekho.Models;
using ComputerSeekho.Repository;
using Microsoft.EntityFrameworkCore;

namespace ComputerSeekho.Service
{
    public class PaymentService: IPaymentService
    {
        private readonly Appdbcontext _context;

        public PaymentService(Appdbcontext context)
        {
            _context = context;
        }

        public async Task AddPayment(Payment payment)
        {
            _context.Payment.Add(payment);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePayment(int id)
        {
            var payment = await _context.Payment.FindAsync(id);
            if (payment != null)
            {
                _context.Payment.Remove(payment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Payment> GetPaymentById(int id)
        {
            return await _context.Payment.FindAsync(id);
        }

        public async Task<IEnumerable<Payment>> GetAllPayments()
        {
            return await _context.Payment.ToListAsync();
        }

        public async Task UpdatePayment(Payment payment)
        {
            _context.Entry(payment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
