using VinylWebShop.Context;
using VinylWebShop.Repository;

namespace VinylWebShop.Services
{
    public class ProfileService(IProfileRepository profileRepository) : IProfileService
    {
        private readonly IProfileRepository _profileRepository = profileRepository ?? throw new ArgumentNullException(nameof(profileRepository));

        public async Task<Profile> GetProfileById(int id)
        {
            return await _profileRepository.GetProfileById(id);
        }

        public async Task<bool> UpdateProfile(int id, Profile updatedProfile)
        {
            return await _profileRepository.UpdateProfile(id, updatedProfile);
        }

        public async Task<bool> DeleteProfile(int id)
        {
            return await _profileRepository.DeleteProfile(id);
        }

        public Task<Profile> AddProfile(Profile profile)
        {
            throw new NotImplementedException();
        }
    }
}