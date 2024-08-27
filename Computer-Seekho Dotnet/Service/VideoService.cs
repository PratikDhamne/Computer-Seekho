using ComputerSeekho.Models;
using ComputerSeekho.Repository;
using Microsoft.EntityFrameworkCore;

namespace ComputerSeekho.Service
{
    public class VideoService: IVideoService
    {
        private readonly Appdbcontext _context;

        public VideoService(Appdbcontext context)
        {
            _context = context;
        }

        public async Task AddVideo(Video video)
        {
            _context.Videos.Add(video);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVideo(int id)
        {
            var video = await _context.Videos.FindAsync(id);
            if (video != null)
            {
                _context.Videos.Remove(video);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Video> GetVideoById(int id)
        {
            return await _context.Videos.FindAsync(id);
        }

        public async Task<IEnumerable<Video>> GetAllVideos()
        {
            return await _context.Videos.ToListAsync();
        }

        public async Task UpdateVideo(Video video)
        {
            _context.Entry(video).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
