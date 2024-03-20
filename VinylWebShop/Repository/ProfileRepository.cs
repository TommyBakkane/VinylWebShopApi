using VinylWebShop.Context;

namespace VinylWebShop.Repository
{

    public class ProfileRepository(VinylShopDbContext dbContext) : IProfileRepository
    {
        private readonly VinylShopDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public async Task<Profile> GetProfileById(int id)
        {
            var profile = await _dbContext.Profiles.FindAsync(id);
            return profile ?? throw new ArgumentException("Profile not found", nameof(id));
        }

        public async Task<Profile> AddProfile(Profile profile)
        {
            ArgumentNullException.ThrowIfNull(profile);

            _dbContext.Profiles.Add(profile);
            await _dbContext.SaveChangesAsync();
            return profile;
        }

        public async Task<bool> DeleteProfile(int id)
        {
            var profileToDelete = await _dbContext.Profiles.FindAsync(id);
            if (profileToDelete == null)
            {
                return false;
            }

            _dbContext.Profiles.Remove(profileToDelete);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateProfile(int id, Profile updatedProfile)
        {
            var profileToUpdate = await _dbContext.Profiles.FindAsync(id);
            if (profileToUpdate == null)
            {
                return false;
            }

            profileToUpdate.Username = updatedProfile.Username;
            profileToUpdate.Email = updatedProfile.Email;
            profileToUpdate.Password = updatedProfile.Password;

            await _dbContext.SaveChangesAsync();
            return true;
        }
    }

}
