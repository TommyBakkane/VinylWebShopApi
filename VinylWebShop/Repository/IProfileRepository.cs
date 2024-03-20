using System.ComponentModel;
using VinylWebShop.Context;

namespace VinylWebShop.Repository
{
    public interface IProfileRepository
    {
        Task<Profile> GetProfileById(int id);
        Task<Profile> AddProfile(Profile profile);
        Task<bool> DeleteProfile(int id);
        Task<bool> UpdateProfile(int id, Profile updatedProfile);
    }
}
