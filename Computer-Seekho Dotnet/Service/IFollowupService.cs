using ComputerSeekho.Models;

namespace ComputerSeekho.Service
{
    public interface IFollowupService
    {
        Task AddFollowup(Followup followup);
        Task DeleteFollowup(int id);
        Task<Followup> GetFollowupById(int id);
        Task<IEnumerable<Followup>> GetAllFollowups();
        Task UpdateFollowup(Followup followup);
    }
}
