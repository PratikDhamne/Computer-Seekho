using ComputerSeekho.Models;
namespace ComputerSeekho.Service
{
    public interface IImageService
    {
        Task AddImage(Image image);
        Task DeleteImage(int id);
        Task<Image> GetImageById(int id);
        Task<IEnumerable<Image>> GetAllImages();
        Task UpdateImage(Image image);
        Task<IEnumerable<Image>> GetImagesByAlbumId(int albumId);
    }
}
