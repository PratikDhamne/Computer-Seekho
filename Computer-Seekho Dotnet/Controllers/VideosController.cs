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
    public class VideosController : ControllerBase
    {
        private readonly IVideoService _videoService;

        public VideosController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        // GET: api/Videos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Video>>> GetVideos()
        {
            var videos = await _videoService.GetAllVideos();
            return Ok(videos);
        }

        // GET: api/Videos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Video>> GetVideo(int id)
        {
            var video = await _videoService.GetVideoById(id);

            if (video == null)
            {
                return NotFound();
            }

            return Ok(video);
        }

        // PUT: api/Videos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideo(int id, Video video)
        {
            if (id != video.VideoId)
            {
                return BadRequest("Video ID mismatch");
            }

            try
            {
                var existingVideo = await _videoService.GetVideoById(id);
                if (existingVideo == null)
                {
                    return NotFound();
                }

                await _videoService.UpdateVideo(video);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log exception details
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/Videos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Video>> PostVideo(Video video)
        {
            if (video == null)
            {
                return BadRequest("Video data is null");
            }

            await _videoService.AddVideo(video);

            return CreatedAtAction(nameof(GetVideo), new { id = video.VideoId }, video);
        }

        // DELETE: api/Videos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideo(int id)
        {
            var video = await _videoService.GetVideoById(id);
            if (video == null)
            {
                return NotFound();
            }

            await _videoService.DeleteVideo(id);

            return NoContent();
        }
    }
}
