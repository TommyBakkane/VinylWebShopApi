using VinylWebShop.Context;
using VinylWebShop.Repository;

namespace VinylWebShop.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IConfiguration _configuration;
        private readonly IProfileRepository _profileRepository;

        public ProfileService(IConfiguration configuration, IProfileRepository profileRepository)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _profileRepository = profileRepository ?? throw new ArgumentNullException(nameof(profileRepository));
        }

        public async Task<Profile> GetProfileById(int id)
        {
            return await _profileRepository.GetProfileById(id);
        }

        public async Task<Profile> GetProfileByUsername(string username)
        {
            return await _profileRepository.GetProfileByUsername(username);
        }

        public async Task<bool> UpdateProfile(int id, Profile updatedProfile)
        {
            return await _profileRepository.UpdateProfile(id, updatedProfile);
        }

        public async Task<bool> DeleteProfile(int id)
        {
            return await _profileRepository.DeleteProfile(id);
        }

        public async Task<Profile> AddProfile(Profile profile)
        {
            if (profile == null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            return await _profileRepository.AddProfile(profile);
        }
    }
}
