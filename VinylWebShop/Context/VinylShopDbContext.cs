using Microsoft.EntityFrameworkCore;

namespace VinylWebShop.Context
{
    public class VinylShopDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public VinylShopDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }
        }
    }
}
