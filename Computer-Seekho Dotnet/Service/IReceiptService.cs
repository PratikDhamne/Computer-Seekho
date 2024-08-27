using ComputerSeekho.Models;

namespace ComputerSeekho.Service
{
    public interface IReceiptService
    {
        Task AddReceipt(Receipt receipt);
        Task DeleteReceipt(int id);
        Task<Receipt> GetReceiptById(int id);
        Task<IEnumerable<Receipt>> GetAllReceipts();
        Task UpdateReceipt(Receipt receipt);
    }
}
