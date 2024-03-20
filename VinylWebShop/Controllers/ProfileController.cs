using Microsoft.AspNetCore.Mvc;
using VinylWebShop.Context;
using VinylWebShop.Services;

namespace VinylWebShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController(IProfileService profileService, ILogger<ProfileController> logger) : ControllerBase
    {
        private readonly IProfileService _profileService = profileService ?? throw new ArgumentNullException(nameof(profileService));
        private readonly ILogger<ProfileController> _logger = logger;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfile(int id)
        {
            var profile = await _profileService.GetProfileById(id);
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [HttpPost]
        public async Task<IActionResult> AddProfile(Profile profile)
        {
            var addedProfile = await _profileService.AddProfile(profile);
            return CreatedAtAction(nameof(GetProfile), new { id = addedProfile.Id }, addedProfile);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            var result = await _profileService.DeleteProfile(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfile(int id, Profile updatedProfile)
        {
            var result = await _profileService.UpdateProfile(id, updatedProfile);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
