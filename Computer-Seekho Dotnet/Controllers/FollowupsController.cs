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
    public class FollowupsController : ControllerBase
    {
        private readonly IFollowupService _followupService;

        public FollowupsController(IFollowupService followupService)
        {
            _followupService = followupService;
        }

        // GET: api/Followups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Followup>>> GetFollowups()
        {
            var followups = await _followupService.GetAllFollowups();
            return Ok(followups);
        }

        // GET: api/Followups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Followup>> GetFollowup(int id)
        {
            var followup = await _followupService.GetFollowupById(id);

            if (followup == null)
            {
                return NotFound();
            }

            return Ok(followup);
        }

        // PUT: api/Followups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFollowup(int id, Followup followup)
        {
            if (id != followup.FollowupId)
            {
                return BadRequest();
            }

            try
            {
                await _followupService.UpdateFollowup(followup);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _followupService.GetFollowupById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Followups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Followup>> PostFollowup(Followup followup)
        {
            if (followup == null)
            {
                return BadRequest();
            }

            await _followupService.AddFollowup(followup);

            return CreatedAtAction(nameof(GetFollowup), new { id = followup.FollowupId }, followup);
        }


    // DELETE: api/Followups/5
    [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFollowup(int id)
        {
            var followup = await _followupService.GetFollowupById(id);
            if (followup == null)
            {
                return NotFound();
            }

            await _followupService.DeleteFollowup(id);

            return NoContent();
        }
    }
}
