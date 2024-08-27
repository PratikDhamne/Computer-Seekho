using ComputerSeekho.Models;
using ComputerSeekho.Repository;
using Microsoft.EntityFrameworkCore;

namespace ComputerSeekho.Service
{
    public class AlbumService : IAlbumservice
    {
        private readonly Appdbcontext _context;

        public AlbumService(Appdbcontext context)
        {
            _context = context;
        }
        public async Task AddAlbum(Album album)
        {
            _context.Albums.Add(album);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAlbum(int id)
        {
            var album = await _context.Albums.FindAsync(id);
            if (album != null)
            {
                _context.Albums.Remove(album);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Album> GetAlbumById(int id)
        {
           return await _context.Albums.FindAsync(id);
            
        }

        public async Task<IEnumerable<Album>> GetAllAlbums()
        {
            return await _context.Albums.ToListAsync();
        }

        public async Task UpdateAlbum(Album album)
        {
            _context.Entry(album).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
