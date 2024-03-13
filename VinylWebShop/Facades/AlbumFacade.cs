using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VinylWebShop.Context;

namespace VinylWebShop.Facades
{
    public class AlbumFacade : IAlbumFacade
    {
        private readonly ILogger<AlbumFacade> _logger;
        private readonly VinylShopDbContext _dbContext;
        public AlbumFacade(VinylShopDbContext dbContext, ILogger<AlbumFacade> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<List<Album>> GetAlbums()
        {
            var albums = await _dbContext.Albums.ToListAsync();
            if (!albums.Any())
            {
                _logger.LogWarning("The list of albums is empty.");
            }
            return albums;
        }

        public async Task<Album> GetAlbumById(int id)
        {
            var album = await _dbContext.Albums.FindAsync(id);

            if (album == null)
            {
                throw new ArgumentException("Album not found", nameof(id));
            }

            return album;
        }

        public async Task<Album> AddAlbum(Album album)
        {

            if (album == null)
            {
                throw new ArgumentNullException(nameof(album));
            }
            _dbContext.Albums.Add(album);
            await _dbContext.SaveChangesAsync();
            return album;
        }

        public async Task<bool> DeleteAlbum(int id)
        {
            var albumToDelete = await _dbContext.Albums.FindAsync(id);

            if (albumToDelete == null)
            {
                return false;
            }

            _dbContext.Albums.Remove(albumToDelete);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAlbum(int id, Album updatedAlbum)
        {
            var albumToUpdate = await _dbContext.Albums.FindAsync(id);

            if (albumToUpdate == null)
            {
                return false;
            }

            albumToUpdate.Title = updatedAlbum.Title;
            albumToUpdate.Image = updatedAlbum.Image;
            albumToUpdate.Artist = updatedAlbum.Artist;
            albumToUpdate.Description = updatedAlbum.Description;

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}


