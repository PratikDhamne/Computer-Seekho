using ComputerSeekho.Models;

namespace ComputerSeekho.Service
{
    public interface IClosureReasonService
    {
        Task AddClosureReason(ClosureReason closureReason);
        Task UpdateClosureReason(ClosureReason closureReason);
        Task DeleteClosureReason(int id);
        Task<ClosureReason> GetClosureReasonById(int id);
        Task<IEnumerable<ClosureReason>> GetAllClosureReasons();
    }
}
