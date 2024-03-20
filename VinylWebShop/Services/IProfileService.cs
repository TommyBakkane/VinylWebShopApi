using VinylWebShop.Context;

namespace VinylWebShop.Services
{
    public interface IProfileService
    {
        Task<Profile> GetProfileById(int id);
        Task<Profile> AddProfile(Profile profile);
        Task<bool> DeleteProfile(int id);
        Task<bool> UpdateProfile(int id, Profile updatedProfile);
    }
}
