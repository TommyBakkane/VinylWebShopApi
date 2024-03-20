using VinylWebShop.Context;

namespace VinylWebShop.Services
{
    public interface IAlbumService
    {
        Task<List<Album>> GetAlbums();
        Task<Album> GetAlbumById(int id);
        Task<Album> AddAlbum(Album album);
        Task<bool> DeleteAlbum(int id);
        Task<bool> UpdateAlbum(int id, Album updatedAlbum);
    }
}
