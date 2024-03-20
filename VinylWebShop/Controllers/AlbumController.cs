using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VinylWebShop.Context;
using VinylWebShop.Services;

namespace VinylWebShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumController(IAlbumService albumService, ILogger<AlbumController> logger) : ControllerBase
    {
        private readonly IAlbumService _albumService = albumService;
        private readonly ILogger<AlbumController> _logger = logger;

        [HttpGet]
        [AllowAnonymous]
        [Route("GetAlbums")]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbums()
        {
            try
            {
                var albums = await _albumService.GetAlbums();
                if (albums.Any())
                {
                    return Ok(albums); 
                }
                else
                {
                    _logger.LogWarning("The list of albums is empty.");
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when fetching albums");
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbumById(int id)
        {
            try
            {
                var album = await _albumService.GetAlbumById(id);

                if (album == null)
                {
                    return NotFound();
                }
                return Ok(album);
            }
            catch(Exception ex) 
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); 
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAlbum([FromBody] Album album)
        {
            if (album == null)
            {
                return BadRequest("Invalid Data");
            }

            var newAlbum = await _albumService.AddAlbum(album);
            return CreatedAtAction(nameof(GetAlbums), new { id = newAlbum.Id }, newAlbum);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            try
            {
                var result = await _albumService.DeleteAlbum(id);

                if (!result)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAlbum(int id, [FromBody] Album updatedAlbum)
        {
            try
            {
                var result = await _albumService.UpdateAlbum(id, updatedAlbum);

                if (!result)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
