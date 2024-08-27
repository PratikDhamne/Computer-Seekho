using ComputerSeekho.Models;

namespace ComputerSeekho.Service
{
    public interface IPaymentTypeService
    {
        Task AddPaymentType(PaymentType paymentType);
        Task DeletePaymentType(int id);
        Task<PaymentType> GetPaymentTypeById(int id);
        Task<IEnumerable<PaymentType>> GetAllPaymentTypes();
        Task UpdatePaymentType(PaymentType paymentType);
    }
}
