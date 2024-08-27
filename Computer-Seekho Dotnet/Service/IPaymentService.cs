using ComputerSeekho.Models;

namespace ComputerSeekho.Service
{
    public interface IPaymentService
    {
        Task AddPayment(Payment payment);
        Task DeletePayment(int id);
        Task<Payment> GetPaymentById(int id);
        Task<IEnumerable<Payment>> GetAllPayments();
        Task UpdatePayment(Payment payment);
    }
}
