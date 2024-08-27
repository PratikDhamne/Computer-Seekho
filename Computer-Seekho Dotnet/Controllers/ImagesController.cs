using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ComputerSeekho.Models;
using ComputerSeekho.Repository;
using ComputerSeekho.Service;

namespace ComputerSeekho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        // GET: api/Images
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Image>>> GetImages()
        {
            try
            {
                var images = await _imageService.GetAllImages();
                return Ok(images);
            }
            catch (Exception ex)
            {
                // Log exception details
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Images/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Image>> GetImage(int id)
        {
            try
            {
                var image = await _imageService.GetImageById(id);
                if (image == null)
                {
                    return NotFound();
                }
                return Ok(image);
            }
            catch (Exception ex)
            {
                // Log exception details
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/Images/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImage(int id, Image image)
        {
            if (id != image.ImageId)
            {
                return BadRequest("Image ID mismatch");
            }

            try
            {
                var existingImage = await _imageService.GetImageById(id);
                if (existingImage == null)
                {
                    return NotFound();
                }

                await _imageService.UpdateImage(image);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log exception details
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/Images
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Image>> PostImage(Image image)
        {
            if (image == null)
            {
                return BadRequest("Image data is null");
            }

            try
            {
                await _imageService.AddImage(image);
                return CreatedAtAction(nameof(GetImage), new { id = image.ImageId }, image);
            }
            catch (Exception ex)
            {
                // Log exception details
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/Images/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            try
            {
                var image = await _imageService.GetImageById(id);
                if (image == null)
                {
                    return NotFound();
                }

                await _imageService.DeleteImage(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log exception details
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        // GET: api/Images/album/5
        [HttpGet("album/{albumId}")]
        public async Task<ActionResult<IEnumerable<Image>>> GetImagesByAlbumId(int albumId)
        {
            try
            {
                var images = await _imageService.GetImagesByAlbumId(albumId);
                if (images == null || !images.Any())
                {
                    return NotFound();
                }
                return Ok(images);
            }
            catch (Exception ex)
            {
                // Log exception details
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
