using ComputerSeekho.Models;

namespace ComputerSeekho.Service
{
    public interface IVideoService
    {
        Task AddVideo(Video video);
        Task DeleteVideo(int id);
        Task<Video> GetVideoById(int id);
        Task<IEnumerable<Video>> GetAllVideos();
        Task UpdateVideo(Video video);
    }
}
