using Microsoft.EntityFrameworkCore;
using VinylWebShop.Context;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VinylWebShop.Repository
{

    public class AlbumRepository : IAlbumRepository
    {
        private readonly VinylShopDbContext _dbContext;

        public AlbumRepository(VinylShopDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<List<Album>> GetAlbums()
        {
            var albums = await _dbContext.Albums.ToListAsync();
            return albums;
        }

        public async Task<Album> GetAlbumById(int id)
        {
            var album = await _dbContext.Albums.FindAsync(id);
            return album ?? throw new ArgumentException("Album not found", nameof(id));
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
