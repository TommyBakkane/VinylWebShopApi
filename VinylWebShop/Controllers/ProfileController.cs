using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VinylWebShop.Context;
using VinylWebShop.Services;

namespace VinylWebShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;
        private readonly ILogger<ProfileController> _logger;

        public ProfileController(IProfileService profileService, ILogger<ProfileController> logger)
        {
            _profileService = profileService ?? throw new ArgumentNullException(nameof(profileService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

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

        [HttpGet("Username/{username}")]
        public async Task<IActionResult> GetProfileByUsername(string username)
        {
            var profile = await _profileService.GetProfileByUsername(username);

            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [HttpPost]
        public async Task<IActionResult> AddProfile(Profile profile)
        {
            try
            {
                var addedProfile = await _profileService.AddProfile(profile);
                return Ok(addedProfile);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message); 
            }
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
