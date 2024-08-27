using ComputerSeekho.Models;

namespace ComputerSeekho.Service
{
    public interface IBatchService
    {
        Task AddBatch(Batch batch);
        Task UpdateBatch(Batch batch);
        Task DeleteBatch(int id);
        Task<Batch> GetBatchById(int id);
        Task<IEnumerable<Batch>> GetAllBatches();
        Task<IEnumerable<Batch>> GetBatchByName(string batchName);
        Task<IEnumerable<Batch>> GetBatchByCourseId(int courseId);
    }
}
