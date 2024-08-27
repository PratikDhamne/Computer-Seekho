using ComputerSeekho.Models;
using ComputerSeekho.Repository;
using Microsoft.EntityFrameworkCore;

namespace ComputerSeekho.Service
{
    public class PaymentTypeService:IPaymentTypeService
    {
        private readonly Appdbcontext _context;

        public PaymentTypeService(Appdbcontext context)
        {
            _context = context;
        }

        public async Task AddPaymentType(PaymentType paymentType)
        {
            _context.PaymentTypes.Add(paymentType);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePaymentType(int id)
        {
            var paymentType = await _context.PaymentTypes.FindAsync(id);
            if (paymentType != null)
            {
                _context.PaymentTypes.Remove(paymentType);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<PaymentType> GetPaymentTypeById(int id)
        {
            return await _context.PaymentTypes.FindAsync(id);
        }

        public async Task<IEnumerable<PaymentType>> GetAllPaymentTypes()
        {
            return await _context.PaymentTypes.ToListAsync();
        }

        public async Task UpdatePaymentType(PaymentType paymentType)
        {
            _context.Entry(paymentType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }   
    }
}
