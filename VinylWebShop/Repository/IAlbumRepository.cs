using VinylWebShop.Context;

namespace VinylWebShop.Repository
{
    public interface IAlbumRepository
    {
        Task<List<Album>> GetAlbums();
        Task<Album> GetAlbumById(int id);
        Task<Album> AddAlbum(Album album);
        Task<bool> DeleteAlbum(int id);
        Task<bool> UpdateAlbum(int id, Album updatedAlbum);
    }
}
