using ComputerSeekho.Models;

namespace ComputerSeekho.Service
{
    public interface IAlbumservice
    {
        Task<Album> GetAlbumById(int id);
        Task<IEnumerable<Album>> GetAllAlbums();
        Task AddAlbum(Album album);
        Task UpdateAlbum(Album album);
        Task DeleteAlbum(int id);
    }
}
