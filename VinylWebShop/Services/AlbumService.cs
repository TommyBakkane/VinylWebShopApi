using VinylWebShop.Context;
using VinylWebShop.Repository;

namespace VinylWebShop.Services
{
    public class AlbumService(IAlbumRepository albumRepository) : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository = albumRepository ?? throw new ArgumentNullException(nameof(albumRepository));

        public async Task<List<Album>> GetAlbums()
        {
            return await _albumRepository.GetAlbums();
        }

        public async Task<Album> GetAlbumById(int id)
        {
            return await _albumRepository.GetAlbumById(id);
        }

        public async Task<Album> AddAlbum(Album album)
        {
            return await _albumRepository.AddAlbum(album);
        }

        public async Task<bool> DeleteAlbum(int id)
        {
            return await _albumRepository.DeleteAlbum(id);
        }

        public async Task<bool> UpdateAlbum(int id, Album updatedAlbum)
        {
            return await _albumRepository.UpdateAlbum(id, updatedAlbum);
        }
    }
}
