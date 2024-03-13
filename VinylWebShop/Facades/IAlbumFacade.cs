using VinylWebShop.Context;

namespace VinylWebShop.Facades
{
    public interface IAlbumFacade
    {
        public Task<List<Album>> GetAlbums();

        public Task<Album> GetAlbumById(int id);

        public Task<Album> AddAlbum(Album album);

        public Task<bool> DeleteAlbum(int id);

        public Task<bool> UpdateAlbum(int id, Album updatedAlbum);
    }
}
