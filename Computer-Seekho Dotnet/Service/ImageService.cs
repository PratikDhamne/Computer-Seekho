using ComputerSeekho.Repository;
using ComputerSeekho.Models;
using Microsoft.EntityFrameworkCore;

namespace ComputerSeekho.Service
{
    public class ImageService: IImageService
    {
        private readonly Appdbcontext _context;

        public ImageService(Appdbcontext context)
        {
            _context = context;
        }

        public async Task AddImage(Image image)
        {
            _context.Images.Add(image);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteImage(int id)
        {
            var image = await _context.Images.FindAsync(id);
            if (image != null)
            {
                _context.Images.Remove(image);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Image> GetImageById(int id)
        {
            return await _context.Images.FindAsync(id);
        }

        public async Task<IEnumerable<Image>> GetAllImages()
        {
            return await _context.Images.ToListAsync();
        }

        public async Task UpdateImage(Image image)
        {
            _context.Entry(image).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Image>> GetImagesByAlbumId(int albumId)
        {
            return await _context.Images
                                 .Where(i => i.AlbumId == albumId)
                                 .ToListAsync();
        }
    }
}
